using System;
using System.IO;
using UnityEngine;

[Serializable]
public class AbilityComponentInfo
{
    public float maxResource;
    public float resourceRegen;
    public bool bUsesMana;
}

public class KAbilityComponent : KUnitComponent
{
    public KBuffableStat maxResource;
    public KBuffableStat resourceRegen;
    public bool bUsesMana;

    public bool bAbilityCastingDisabled;
    public bool bPassiveAbilityDisabled;

    public override void Initialize()
    {
        base.Initialize();

        AbilityComponentInfo info = ReadJson<AbilityComponentInfo>("ability");

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
