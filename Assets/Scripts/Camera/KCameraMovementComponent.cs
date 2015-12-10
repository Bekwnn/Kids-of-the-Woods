using UnityEngine;
using System.Collections;

public class KCameraMovementComponent : MonoBehaviour
{
    // main component
    public KCameraPawn cameraPawn;

    // lerps between two postions/rotations 
    public Vector3 zoomOutPosition;
    public Vector3 zoomOutRotation;
    public Vector3 zoomInPosition;
    public Vector3 zoomInRotation;
    protected float zoomValue;

    // middle mouse drag around
    public Vector3 middleDragDownPosition;
    public bool bDraggingCamera;

    //values for disabling movement
    public bool bCanMove = true;
    public bool bCanZoom = true;

    // empty used for movement/focal point
    public int scrollMargin;
    public GameObject anchor;
    public float anchorTransitionSpeed;
    public float anchorMaxSpeed;
    protected Vector3 anchorVelocity;

    void Update()
    {
        // only update zoom and position if not box selecting
        if (bCanZoom) UpdateCameraZoom();
        if (bCanMove)
        {
            if (Input.GetMouseButton(2)) UpdateCameraDrag();
            else UpdateCameraScroll();
        }
    }

    protected void UpdateCameraZoom()
    {
        float scrollVal = Input.GetAxis("Mouse ScrollWheel");
        if (scrollVal != 0)
        {
            // change zoom value
            zoomValue -= scrollVal;
            zoomValue = Mathf.Clamp01(zoomValue);

            // update camera position/rotation lerp
            transform.localPosition = Vector3.Lerp(zoomInPosition, zoomOutPosition, zoomValue);
            transform.localRotation = Quaternion.Euler(Vector3.Lerp(zoomInRotation, zoomOutRotation, zoomValue));
        }
    }

    protected void UpdateCameraScroll()
    {
        Vector3 velocityChange = new Vector3();
        if (Input.mousePosition.x < scrollMargin)
        {
            // scroll left
            velocityChange.x = -1f;
        }
        else if (Input.mousePosition.x > Screen.width - scrollMargin)
        {
            // scroll right
            velocityChange.x = 1f;
        }

        if (Input.mousePosition.y < scrollMargin)
        {
            // scroll down
            velocityChange.z = -1f;
        }
        else if (Input.mousePosition.y > Screen.height - scrollMargin)
        {
            // scroll up
            velocityChange.z = 1f;
        }
        velocityChange.Normalize();

        // apply acceleration
        anchorVelocity = anchorVelocity * (1 - Time.deltaTime * anchorTransitionSpeed) + (velocityChange * anchorMaxSpeed) * (Time.deltaTime * anchorTransitionSpeed);
        anchor.transform.position += anchorVelocity;
    }

    protected void UpdateCameraDrag()
    {
        Ray ray = cameraPawn.cameraComponent.ScreenPointToRay(Input.mousePosition);
        float distToPlane;
        if (Input.GetMouseButtonDown(2))
        {
            if (KCameraPawn.defaultPlane.Raycast(ray, out distToPlane))
                middleDragDownPosition = ray.GetPoint(distToPlane);

            return;
        }

        if (KCameraPawn.defaultPlane.Raycast(ray, out distToPlane))
        {
            Vector3 dragDiff = ray.GetPoint(distToPlane) - middleDragDownPosition;
            anchor.transform.position -= dragDiff;
        }
    }
}
