using UnityEngine;
using System.Collections;

public class KAttackUnitOrder : KUnitOrder
{
    public static float FOLLOWACCEPTRADIUS = 2f;
    protected KUnit targetUnit; //TODO: needs to support structures later (attackable interface)

    public KAttackUnitOrder(KUnitAI ai, KUnit attackTarget)
    {
        aiController = ai;
        targetUnit = attackTarget;
    }

    public override void Execute()
    {
        aiController.unit.AutoAttackTarget(targetUnit);
    }

    public override void OrderUpdate()
    {
        //TODO: check if unit dead or not visible and stop finish order if so
        if (Vector3.Distance(aiController.transform.position, targetUnit.transform.position) < FOLLOWACCEPTRADIUS)
        {
            OrderFinished();
        }
    }
}
