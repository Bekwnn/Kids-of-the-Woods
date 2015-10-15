using UnityEngine;
using System.Collections;

public class KAttackMoveOrder : KUnitOrder
{
    protected Vector3 targetLocation;

    public KAttackMoveOrder(KUnitAI ai, Vector3 movePosition)
    {
        aiController = ai;
        targetLocation = movePosition;
    }

    public override void Execute()
    {
        aiController.IssueAttackMoveOrder(targetLocation);
    }
}
