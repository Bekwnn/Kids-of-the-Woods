using UnityEngine;
using System.Collections;

public class KMoveOrder : KUnitOrder
{
    public static float MOVEACCEPTRADIUS = 1f;
    protected Vector3 targetLocation;

    public KMoveOrder(KUnitAI ai, Vector3 movePosition)
    {
        aiController = ai;
        targetLocation = movePosition;
    }

    public override void Execute()
    {
        aiController.unit.MoveToLocation(targetLocation);
    }

    public override void OrderUpdate()
    {
        if (Vector3.Distance(aiController.transform.position, targetLocation) < MOVEACCEPTRADIUS)
        {
            OrderFinished();
        }
    }
}
