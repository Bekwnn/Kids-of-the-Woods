using UnityEngine;
using System.Collections;

public class KGatherOrder : KUnitOrder
{
    public static float GATHERACCEPTRADIUS = 2f;
    protected KResourceComponent gatherTarget;   //TODO: change to gathernode

    public KGatherOrder(KUnitAI ai, KResourceComponent collectTarget)
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
        if (Vector3.Distance(aiController.transform.position, gatherTarget.transform.position) < GATHERACCEPTRADIUS)
        {
            OrderFinished();
        }
    }
}
