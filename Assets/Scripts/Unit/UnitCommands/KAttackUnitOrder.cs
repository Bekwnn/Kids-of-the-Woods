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
        //do nothing
    }

    public override void OrderUpdate()
    {
        //TODO: check if unit dead or not visible and stop finish order if so
        if (aiController.unit.IsInAttackRange(targetUnit))
        {
            Debug.Log("Is in attack range!");
            aiController.unit.StopMoving();
            aiController.unit.AutoAttackTarget(targetUnit);
        }
        else
        {
            aiController.unit.MoveToLocation(targetUnit.transform.position);
        }
    }
}
