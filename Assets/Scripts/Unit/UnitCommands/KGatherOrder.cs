using UnityEngine;
using System.Collections;

public class KGatherOrder : KUnitOrder
{
    public static float GATHERACCEPTRADIUS = 2f;
    protected KUnit gatherTarget;

    public KGatherOrder(KUnitAI ai, KUnit collectTarget)
    {
        aiController = ai;
        gatherTarget = collectTarget;
    }

    public override void Execute()
    {
        // TODO temporary, move order
        aiController.unit.GatherResource(gatherTarget);
    }

    public override void OrderUpdate()
    {
        if (aiController.unit.IsInAttackRange(gatherTarget))
        {
            Debug.Log("Is in gather range!");
            aiController.unit.StopMoving();
            aiController.unit.GatherResource(gatherTarget);
        }
        else
        {
            aiController.unit.MoveToLocation(gatherTarget.transform.position);
        }
    }
}
