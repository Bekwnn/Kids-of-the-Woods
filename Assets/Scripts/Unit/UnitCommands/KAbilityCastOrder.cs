using UnityEngine;

//TODO: figure out how to handle ability cast orders
public class KAbilityCastOrder : KUnitOrder
{
    public static float MOVEACCEPTRADIUS = 1f; //TODO replace with ability cast range
    protected KAbility ability;
    protected KCastParams castParams;

    public KAbilityCastOrder(KUnitAI ai, KAbility ability, KCastParams abilityParams)
    {
        aiController = ai;
        castParams = abilityParams;
    }

    public override void Execute()
    {
        aiController.unit.MoveToLocation(castParams.targetLocation);
    }

    //TODO: order finishes when ability cast animation starts
    public override void OrderUpdate()
    {
        if (Vector3.Distance(aiController.transform.position, castParams.targetLocation) < MOVEACCEPTRADIUS)
        {
            aiController.unit.CastAbility(ability, castParams);
            OrderFinished();
        }
    }
}
