using UnityEngine;
using System.Collections;

public class KFollowOrder : KUnitOrder
{
    public static float FOLLOWACCEPTRADIUS = 2f;
    protected KUnit targetUnit;

    public KFollowOrder(KUnitAI ai, KUnit followTarget)
    {
        aiController = ai;
        targetUnit = followTarget;
    }

    public override void Execute()
    {
        // TODO temporary, move order
        aiController.unit.MoveToLocation(targetUnit.transform.position);
    }

    public override void OrderUpdate()
    {
        aiController.unit.MoveToLocation(targetUnit.transform.position); //update move order TODO make better
        if (Vector3.Distance(aiController.transform.position, targetUnit.transform.position) < FOLLOWACCEPTRADIUS)
        {
            OrderFinished();
        }
    }
}
