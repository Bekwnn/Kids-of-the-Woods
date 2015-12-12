using UnityEngine;
using System;

[Serializable]
public class AutoAttackComponentInfo
{
    public float attackDamage;
    public float attackSpeed;
    public float criticalChance;
    public float criticalDamage;
    public float attackRange;
}

public class KAutoAttackComponent : KUnitComponent
{
    public KBuffableStat attackDamage;
    public KBuffableStat attackSpeed;
    public KBuffableStat criticalChance;
    public KBuffableStat criticalDamage;
    public KBuffableStat attackRange;

    void Awake()
    {
        // can set stats here
    }

    public void TryAttackingTarget(KUnit target)
    {
        Debug.Log("Attempting to attack target");
    }

    protected void StartAttack()
    {
        //TODO
    }

    protected void LaunchAttack()
    {
        //TODO
    }
}
