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
}
