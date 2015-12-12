using UnityEngine;
using System.Collections;

public class KAttackUnitOrder : KUnitOrder
{
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
        if (aiController.unit.IsInAttackRange(targetUnit))
        {
            aiController.unit.StopMoving();
            aiController.unit.AutoAttackTarget(targetUnit);
        }
        else
        {
            aiController.unit.MoveToLocation(targetUnit.transform.position);
        }
    }
}
