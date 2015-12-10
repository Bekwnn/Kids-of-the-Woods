using UnityEngine;

//TODO: figure out how to handle ability cast orders
public class KAbilityCastOrder : KUnitOrder
{
    public static float MOVEACCEPTRADIUS = 1f; //TODO replace with ability cast range
    protected KAbility ability;
    protected Vector3 abilityTargetLocation;

    public KAbilityCastOrder(KUnitAI ai, KAbility ability, Vector3 targetLocation)
    {
        aiController = ai;
        abilityTargetLocation = targetLocation;
    }

    public override void Execute()
    {
        aiController.unit.MoveToLocation(abilityTargetLocation);
    }

    //TODO: order finishes when ability cast animation starts
    public override void OrderUpdate()
    {
        if (Vector3.Distance(aiController.transform.position, abilityTargetLocation) < MOVEACCEPTRADIUS)
        {
            aiController.unit.CastAbility(ability);
            OrderFinished();
        }
    }
}
