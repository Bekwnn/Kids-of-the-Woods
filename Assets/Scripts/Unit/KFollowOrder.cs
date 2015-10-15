using UnityEngine;
using System.Collections;

public class KFollowOrder : KUnitOrder
{
    protected KUnit targetUnit;

    public KFollowOrder(KUnitAI ai, KUnit followTarget)
    {
        aiController = ai;
        targetUnit = followTarget;
    }

    public override void Execute()
    {
        aiController.IssueFollowOrder(targetUnit);
    }
}
