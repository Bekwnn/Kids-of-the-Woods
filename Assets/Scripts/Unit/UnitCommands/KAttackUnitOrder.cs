using UnityEngine;
using System.Collections;

public class KAttackUnitOrder : KUnitOrder
{
    public static float FOLLOWACCEPTRADIUS = 2f;
    protected KUnit targetUnit;

    public KAttackUnitOrder(KUnitAI ai, KUnit attackTarget)
    {
        aiController = ai;
        targetUnit = attackTarget;
    }

    public override void Execute()
    {
        // TODO move order, temporary
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
