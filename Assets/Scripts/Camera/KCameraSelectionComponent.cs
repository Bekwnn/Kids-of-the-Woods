using UnityEngine;
using System.Collections;

public class KCameraSelectionComponent : MonoBehaviour
{
    // main component
    public KCameraPawn cameraPawn;

    // box selection rectangle drawing
    protected Vector2 buttonDownPosition;
    protected Vector2 buttonUpPosition;
    protected Vector3 buttonDownWorld;
    protected Vector3 buttonUpWorld;
    protected bool bBoxSelecting;
    public GUIStyle boxSelectStyle;
    // minimum distance between mouse down and mouse up to box select
    public float BOXSELECTMINIMUM;
    // height of the box select collision box
    public float BOXHEIGHT;

    // clicks get raycast against this plane if they fail to strike anything
    public static Plane defaultPlane;

    void Awake()
    {
        defaultPlane = new Plane(Vector3.up, 0f);
    }

    void Update()
    {
        if (cameraPawn.orderComponent == null || !cameraPawn.orderComponent.bTryingToCast)
        {
            SelectionUpdate();
        }
    }

    void OnGUI()
    {
        if (bBoxSelecting && (buttonDownPosition - buttonUpPosition).magnitude > BOXSELECTMINIMUM)
        {
            GUI.Box(new Rect(
                Mathf.Min(buttonDownPosition.x, buttonUpPosition.x),
                Mathf.Min(Screen.height - buttonDownPosition.y, Screen.height - buttonUpPosition.y),
                Mathf.Abs(buttonDownPosition.x - buttonUpPosition.x),
                Mathf.Abs(buttonDownPosition.y - buttonUpPosition.y)),
                "",
                boxSelectStyle);
        }
    }

    protected void SelectionUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bBoxSelecting = true;
            cameraPawn.movementComponent.bCanMove = false;
            cameraPawn.movementComponent.bCanZoom = false;
            buttonDownPosition = Input.mousePosition;

            buttonDownWorld = ScreenPointToWorld(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            buttonUpPosition = Input.mousePosition;
        }

        // end and select
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log((buttonUpPosition - buttonDownPosition).magnitude);

            buttonUpWorld = ScreenPointToWorld(Input.mousePosition);

            if ((buttonUpPosition - buttonDownPosition).magnitude > BOXSELECTMINIMUM)
            {
                BoxSelect(buttonDownWorld, buttonUpWorld);
            }
            else
            {
                SingleSelect(buttonUpPosition);
            }

            bBoxSelecting = false;
            cameraPawn.movementComponent.bCanMove = true;
            cameraPawn.movementComponent.bCanZoom = true;
            buttonDownPosition = Vector2.zero;
            buttonUpPosition = Vector2.zero;
        }
    }

    protected Vector3 ScreenPointToWorld(Vector2 screenPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        // use default plane if no terrain struck
        else
        {
            float distToPlane;
            if (defaultPlane.Raycast(ray, out distToPlane))
            {
                return ray.GetPoint(distToPlane);
            }
        }

        return Vector3.zero;
    }

    protected void BoxSelect(Vector3 posA, Vector3 posB)
    {
        // create box select object and set position
        GameObject boxAnchor = new GameObject("boxSelection");
        boxAnchor.transform.position = (posA + posB) * 0.5f;

        // add collider and make it the size of selection area
        BoxCollider collider = boxAnchor.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(Mathf.Abs(posA.x - posB.x), BOXHEIGHT, Mathf.Abs(posA.z - posB.z));

        //TODO: collision with box select area and get all KUnits inside
    }

    protected void SingleSelect(Vector2 screenPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                KUnit hitUnit = hit.collider.gameObject.GetComponent<KUnit>();
                if (hitUnit != null)
                {
                    cameraPawn.owningPlayer.SelectUnit(hitUnit);
                }
                else
                {
                    DeselectAll();
                }
            }
        }
    }

    public void DeselectAll()
    {
        cameraPawn.owningPlayer.DeselectAll();
    }
}
