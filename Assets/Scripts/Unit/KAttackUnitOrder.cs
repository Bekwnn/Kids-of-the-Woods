using UnityEngine;
using System.Collections;

public class KAttackUnitOrder : KUnitOrder
{
    protected KUnit targetUnit;

    public KAttackUnitOrder(KUnitAI ai, KUnit attackTarget)
    {
        aiController = ai;
        targetUnit = attackTarget;
    }

    public override void Execute()
    {
        aiController.IssueAttackUnitOrder(targetUnit);
    }
}
