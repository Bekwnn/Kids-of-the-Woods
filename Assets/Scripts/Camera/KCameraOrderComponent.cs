using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The camera component which handles issuing selected units orders. Includes move orders, spell cast orders, attack orders, hold position orders, etc.
/// </summary>
public class KCameraOrderComponent : MonoBehaviour
{
    // ref to management component
    public KCameraPawn cameraPawn;
    
    // spell order tracking
    public bool bTryingToCast { get; protected set; }
	public KAbility abilityToCast { get; protected set; }
	public KCastParams castParams { get; protected set; }
	protected int targetsToPick;
	protected bool bQueueSpellOrder;

    void Update()
    {
		//handle spell cast commands:
		bool bUnitsSelected = (cameraPawn.owningPlayer.selectedUnits != null && cameraPawn.owningPlayer.selectedUnits.Count > 0);
		if (Input.GetButtonDown("Spell1"))
		{
			if (bUnitsSelected)
				PrepareCast(cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.qAbility);
		}
		else if (Input.GetButtonDown("Spell2"))
		{
			if (bUnitsSelected)
				PrepareCast(cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.wAbility);
		}
		else if (Input.GetButtonDown("Spell3"))
		{
			if (bUnitsSelected)
				PrepareCast(cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.eAbility);
		}
		else if (Input.GetButtonDown("Spell4"))
		{
			if (bUnitsSelected)
				PrepareCast(cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.rAbility);
		}
		else if (Input.GetButtonDown("Spell5"))
		{
			if (bUnitsSelected)
				PrepareCast(cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.dAbility);
		}
		else if (Input.GetButtonDown("Spell6"))
		{
			if (bUnitsSelected)
				PrepareCast(cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.fAbility);
		}

        if (!bTryingToCast)
        {
            IssueOrderUpdate();
        }
        else
        {
            IssueCastUpdate();
        }
    }

    protected void IssueOrderUpdate()
    {
        if (Input.GetMouseButtonDown(1))
		{
            if (Input.GetKey(KeyCode.LeftShift))
            {
                KUnit unitHit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);

                if (unitHit != null)
                {
                    // issue attack order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.QueueAttackUnitOrder(unitHit);
                    }
                }
                else
                {
                    // issue move order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.QueueMoveOrder(
								KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent));
                    }
                }
            }
            else
            {
                KUnit unitHit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);

                if (unitHit != null)
                {
                    // issue attack order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.IssueAttackUnitOrder(unitHit);
                    }
                }
                else
                {
                    // issue move order to all selected units
                    foreach (KUnit unit in cameraPawn.owningPlayer.selectedUnits)
                    {
                        unit.aiController.IssueMoveOrder(KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent));
                    }
                }
            }
        }
    }

    protected void IssueCastUpdate()
    {
        if (Input.GetMouseButtonDown(0))
		{
			if (castParams.targetLocations == null) castParams.targetLocations = new List<Vector3>();
			if (castParams.targetUnits == null) castParams.targetUnits = new List<KUnit>();
			castParams.targetUnits.Add(KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent));
			castParams.targetLocations.Add(KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent));
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // cancel ability cast
			bTryingToCast = false;
			castParams = new KCastParams();
			abilityToCast = null;
			targetsToPick = 0;
        }
    }

	protected void PrepareCast(KAbility ability)
	{
		KCastParams instParams = new KCastParams();

		//get the mode and set
		if (ability.castMethod == EAbilityCastMethod.ONPRESS)
		{
			instParams.targetUnit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);
			instParams.targetLocation = KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent);
			if (Input.GetKey(KeyCode.LeftShift))
				cameraPawn.owningPlayer.selectedUnits[0].aiController.QueueAbilityCastOrder(abilityToCast, instParams);
			else
				cameraPawn.owningPlayer.selectedUnits[0].aiController.IssueAbilityCastOrder(abilityToCast, instParams);
		}
		else
		{
			abilityToCast = ability;
			bTryingToCast = true;

			if (ability.castMethod == EAbilityCastMethod.LINEDRAG)
			{
				targetsToPick = 2;
			}
			else
			{
				targetsToPick = 1;
			}
		}
	}
}
