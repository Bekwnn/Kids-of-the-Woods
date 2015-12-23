using System;
using System.IO;
using UnityEngine;

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

    public void CastAbility(KAbility ability)
    {

    }
}
