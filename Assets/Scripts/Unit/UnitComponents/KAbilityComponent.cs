using System;
using System.IO;
using UnityEngine;

public enum EAbilitySlot
{
	Q,
	W,
	E,
	R,
	D,
	F,
	NONE
}

[Serializable]
public class JAbilityComponentInfo
{
    public float maxResource;
    public float resourceRegen;
    public bool bUsesMana;
}

/// <summary>
/// The KUnit component which keeps track of a unit's abilities.
/// </summary>
public class KAbilityComponent : KUnitComponent
{
    [HideInInspector]
    public KBuffableStat maxResource;

    [HideInInspector]
    public KBuffableStat resourceRegen;

    public bool bUsesMana;
	public int availableSkillPoints;

    public KAbility qAbility;
    public KAbility wAbility;
    public KAbility eAbility;
    public KAbility rAbility;
    public KAbility dAbility;
    public KAbility fAbility;

    public bool bAbilityCastingDisabled;
    public bool bPassiveAbilityDisabled;

    public override void Initialize()
    {
        base.Initialize();

        JAbilityComponentInfo info = ReadJson<JAbilityComponentInfo>("ability");

        //assign values from json info
        maxResource = new KBuffableStat(info.maxResource);
        resourceRegen = new KBuffableStat(info.resourceRegen);
        bUsesMana = info.bUsesMana;
    }

    public void RestoreResource(float amount)
    {

    }

	public void CastAbility(EAbilitySlot abilitySlot, KCastParams castParams)
	{
		switch (abilitySlot)
		{
			case EAbilitySlot.Q:
				qAbility.CastActive(castParams);
				break;
			case EAbilitySlot.W:
				wAbility.CastActive(castParams);
				break;
			case EAbilitySlot.E:
				eAbility.CastActive(castParams);
				break;
			case EAbilitySlot.R:
				rAbility.CastActive(castParams);
				break;
			case EAbilitySlot.D:
				dAbility.CastActive(castParams);
				break;
			case EAbilitySlot.F:
				fAbility.CastActive(castParams);
				break;
			default:
				break;
		}
	}

	public KAbility GetAbility(EAbilitySlot abilitySlot)
	{
		switch (abilitySlot)
		{
			case EAbilitySlot.Q:
				return (qAbility == null)? null : qAbility;
			case EAbilitySlot.W:
				return (wAbility == null)? null : wAbility;
			case EAbilitySlot.E:
				return (eAbility == null)? null : eAbility;
			case EAbilitySlot.R:
				return (rAbility == null)? null : rAbility;
			case EAbilitySlot.D:
				return (dAbility == null)? null : dAbility;
			case EAbilitySlot.F:
				return (fAbility == null)? null : fAbility;
			default:
				return null;
		}
	}

	public bool AllocateSkillPoint(EAbilitySlot abilitySlot)
	{
		KAbility abilityToLevel;
		switch (abilitySlot)
		{
			case EAbilitySlot.Q:
				abilityToLevel = qAbility;
				break;
			case EAbilitySlot.W:
				abilityToLevel = wAbility;
				break;
			case EAbilitySlot.E:
				abilityToLevel = eAbility;
				break;
			case EAbilitySlot.R:
				abilityToLevel = rAbility;
				break;
			case EAbilitySlot.D:
				abilityToLevel = dAbility;
				break;
			case EAbilitySlot.F:
				abilityToLevel = fAbility;
				break;
			default:
				return false;
		}

		if (abilityToLevel == null) return false;
		else if (abilityToLevel.abilityLevel < abilityToLevel.abilityMaxLevel)
		{
			abilityToLevel.abilityLevel++;
			availableSkillPoints--;
			return true;
		}
		else return false;
	}
}
