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
        aiController.navAgent.SetDestination(targetUnit.transform.position);
    }

    public override void OrderUpdate()
    {
        if (Vector3.Distance(aiController.transform.position, targetUnit.transform.position) < FOLLOWACCEPTRADIUS)
        {
            OrderFinished();
        }
    }
}
