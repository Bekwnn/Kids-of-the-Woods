﻿using UnityEngine;
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
	public EAbilitySlot abilityToCast { get; protected set; }
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
				PrepareCast(EAbilitySlot.Q);
		}
		else if (Input.GetButtonDown("Spell2"))
		{
			if (bUnitsSelected)
				PrepareCast(EAbilitySlot.W);
		}
		else if (Input.GetButtonDown("Spell3"))
		{
			if (bUnitsSelected)
				PrepareCast(EAbilitySlot.E);
		}
		else if (Input.GetButtonDown("Spell4"))
		{
			if (bUnitsSelected)
				PrepareCast(EAbilitySlot.R);
		}
		else if (Input.GetButtonDown("Spell5"))
		{
			if (bUnitsSelected)
				PrepareCast(EAbilitySlot.D);
		}
		else if (Input.GetButtonDown("Spell6"))
		{
			if (bUnitsSelected)
				PrepareCast(EAbilitySlot.F);
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

			//if we've picked all our targets, cast spell
			if (--targetsToPick <= 0)
			{
				if (Input.GetKey(KeyCode.LeftShift))
					cameraPawn.owningPlayer.selectedUnits[0].aiController.QueueAbilityCastOrder(abilityToCast, castParams);
				else
					cameraPawn.owningPlayer.selectedUnits[0].aiController.IssueAbilityCastOrder(abilityToCast, castParams);

				CancelCast();
			}

        }
        else if (Input.GetMouseButtonDown(1))
        {
            CancelCast();
        }
    }

	public void CancelCast()
	{
		bTryingToCast = false;
		castParams = new KCastParams();
		abilityToCast = EAbilitySlot.NONE;
		targetsToPick = 0;
	}

	protected void PrepareCast(EAbilitySlot abilitySlot)
	{
		castParams = new KCastParams();

		if (cameraPawn.owningPlayer.selectedUnits[0].abilityComponent == null)
		{
			Debug.Log("Unit has no abilities.");
			return;
		}
		KAbility ability = cameraPawn.owningPlayer.selectedUnits[0].abilityComponent.GetAbility(abilitySlot);
		if (ability == null)
		{
			Debug.Log("Unit does not have that ability.");
			return;
		}

		//get the mode and set
		if (ability.castMethod == EAbilityCastMethod.ONPRESS)
		{
			castParams.targetUnit = KCameraPawn.GetUnitUnderScreenPos(Input.mousePosition, cameraPawn.cameraComponent);
			castParams.targetLocation = KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, cameraPawn.cameraComponent);
			if (Input.GetKey(KeyCode.LeftShift))
				cameraPawn.owningPlayer.selectedUnits[0].aiController.QueueAbilityCastOrder(abilityToCast, castParams);
			else
				cameraPawn.owningPlayer.selectedUnits[0].aiController.IssueAbilityCastOrder(abilityToCast, castParams);
		}
		else
		{
			abilityToCast = abilitySlot;
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
