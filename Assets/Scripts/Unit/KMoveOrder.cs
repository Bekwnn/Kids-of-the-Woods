using UnityEngine;
using System.Collections;

public class KMoveOrder : KUnitOrder
{
    protected Vector3 targetLocation;

    public KMoveOrder(KUnitAI ai, Vector3 movePosition)
    {
        aiController = ai;
        targetLocation = movePosition;
    }

    public override void Execute()
    {
        aiController.IssueMoveOrder(targetLocation);
    }
}
