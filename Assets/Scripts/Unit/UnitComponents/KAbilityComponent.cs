using System;

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

    public void RestoreResource(float amount)
    {

    }

    public void CastAbility(KAbility ability)
    {

    }
}
