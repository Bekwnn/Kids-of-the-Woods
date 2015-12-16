using UnityEngine;

/// <summary>
/// The camera component in charge of selecting units: friendly or enemy. Handles box selection, etc.
/// </summary>
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

            buttonDownWorld = KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent);
        }

        if (Input.GetMouseButton(0))
        {
            buttonUpPosition = Input.mousePosition;
        }

        // end and select
        if (Input.GetMouseButtonUp(0))
        {
            buttonUpWorld = KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent);

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
        //shift select
        if (Input.GetKey(KeyCode.LeftShift))
        {
            KUnit hitUnit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);
            if (hitUnit != null)
            {
                cameraPawn.owningPlayer.SelectUnit(hitUnit);
            }
        }
        //regular select (TODO: CTRL select)
        else
        {
            KUnit hitUnit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);
            if (hitUnit != null)
            {
                DeselectAll();
                cameraPawn.owningPlayer.SelectUnit(hitUnit);
            }
            else
            {
                DeselectAll();
            }
        }
    }

    public void DeselectAll()
    {
        cameraPawn.owningPlayer.DeselectAll();
    }
}
