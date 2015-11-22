using UnityEngine;
using System.Collections;

public class KBuildOrder : KUnitOrder
{
    public static float BUILDRADIUS = 1f;
    protected Vector3 buildLocation;

    public KBuildOrder(KUnitAI ai, Vector3 buildPosition)
    {
        aiController = ai;
        buildLocation = buildPosition;
    }

    public override void Execute()
    {
        aiController.navAgent.SetDestination(buildLocation);
    }

    public override void OrderUpdate()
    {
        if (Vector3.Distance(aiController.transform.position, buildLocation) < BUILDRADIUS)
        {
            OrderFinished();
        }
    }
}
