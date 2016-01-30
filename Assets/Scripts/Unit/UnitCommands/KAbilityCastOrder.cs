using UnityEngine;

//TODO: figure out how to handle ability cast orders
public class KAbilityCastOrder : KUnitOrder
{
    protected EAbilitySlot abilitySlot;
    protected KCastParams castParams;

    public KAbilityCastOrder(KUnitAI ai, EAbilitySlot abilitySlot, KCastParams castingParams)
    {
        aiController = ai;
        castParams = castingParams;
    }

    public override void Execute()
    {
        aiController.unit.MoveToLocation(castParams.targetLocation);
    }

    //TODO: order finishes when ability cast animation starts
    public override void OrderUpdate()
    {
		float range = aiController.unit.abilityComponent.GetAbility(abilitySlot).range;
        if (Vector3.Distance(aiController.transform.position, castParams.targetLocation) < range || range == 0f)
        {
			aiController.unit.StopMoving();
            aiController.unit.CastAbility(abilitySlot, castParams);
            OrderFinished();
        }
    }
}
