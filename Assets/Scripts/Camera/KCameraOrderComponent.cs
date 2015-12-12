using UnityEngine;
using System.Collections;

/*
 * Component allows camera pawn to issue orders to units and cast abilities
 */

public class KCameraOrderComponent : MonoBehaviour
{
    // ref to management component
    public KCameraPawn cameraPawn;
    
    // true if ability is prepped on cursor to cast
    public bool bTryingToCast { get; protected set; }

    void Update()
    {
        if (!bTryingToCast)
        {
            IssueOrderUpdate();
        }
        else
        {
            IssueCastUpdate();
        }
    }

    protected void IssueOrderUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                KUnit unitHit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);

                if (unitHit != null)
                {
                    // issue attack order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.QueueAttackUnitOrder(unitHit);
                    }
                }
                else
                {
                    // issue move order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.QueueMoveOrder(KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent));
                    }
                }
            }
            else
            {
                KUnit unitHit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);

                if (unitHit != null)
                {
                    // issue attack order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.IssueAttackUnitOrder(unitHit);
                    }
                }
                else
                {
                    // issue move order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.IssueMoveOrder(KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent));
                    }
                }
            }
        }
    }

    protected void IssueCastUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast ability at cursor selection
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // cancel ability cast
        }
    }
}
