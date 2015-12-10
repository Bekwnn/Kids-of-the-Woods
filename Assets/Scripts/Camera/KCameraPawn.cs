using UnityEngine;
using System.Collections;

[RequireComponent (typeof (KCameraMovementComponent))]
[RequireComponent(typeof (KCameraSelectionComponent))]

/*
 * Management component for various camera pawn systems
 */

public class KCameraPawn : MonoBehaviour
{
    // reference to owning player:
    public KPlayerState owningPlayer;

    //camera component
    public Camera cameraComponent;

    // required CameraPawn components:
    public KCameraMovementComponent movementComponent;
    public KCameraSelectionComponent selectionComponent;

    // optional CameraPawnComponents:
    public KCameraOrderComponent orderComponent;

    // clicks get raycast against this plane if they fail to strike anything
    protected static Plane _defaultPlane;
    protected static bool bDefaultPlaneInitialized;
    public static Plane defaultPlane
    {
        get
        {
            if (!bDefaultPlaneInitialized)
            {
                defaultPlane = new Plane(Vector3.up, 0f);
                bDefaultPlaneInitialized = true;
            }
            return _defaultPlane;
        }
        protected set
        {
            _defaultPlane = value;
        }
    }

    void Reset()
    {
        if (cameraComponent == null) cameraComponent = GetComponent<Camera>();
    }

    // tries to hit terrain, returns a hit against the default plane if no terrain found
    public static Vector3 ScreenPointToGameWorld(Vector2 screenPos, Camera camera, bool bOnlyUseDefaultPlane = false)
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPos);
        if (bOnlyUseDefaultPlane)
        {
            float distToPlane;
            if (KCameraPawn.defaultPlane.Raycast(ray, out distToPlane))
            {
                return ray.GetPoint(distToPlane);
            }
        }

        else
        {
            if (Physics.Raycast(ray, out hit))
            {
                return hit.point;
            }
            // use default plane if no terrain struck
            else
            {
                float distToPlane;
                if (KCameraPawn.defaultPlane.Raycast(ray, out distToPlane))
                {
                    return ray.GetPoint(distToPlane);
                }
            }
        }

        return Vector3.zero;
    }

    public static KUnit GetUnitUnderScreenPos(Vector2 screenPos, Camera camera)
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                KUnit unitHit = hit.collider.gameObject.GetComponent<KUnit>();
                if (unitHit != null) return unitHit;
            }
        }
        return null;
    }
}
