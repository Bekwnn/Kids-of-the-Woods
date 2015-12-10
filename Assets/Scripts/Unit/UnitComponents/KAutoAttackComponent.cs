using UnityEngine;
using System.Collections;

public class KAutoAttackComponent : KUnitComponent
{
    public KBuffableStat attackDamage;
    public KBuffableStat attackSpeed;
    public KBuffableStat criticalChance;
    public KBuffableStat criticalDamage;
    public KBuffableStat attackRange;

    public void TryAttackingTarget(KUnit Target)
    {
        //TODO logic for chasing and attacking goes here
    }

    protected void LaunchAttack()
    {
        //TODO
    }

    protected void StartAttack()
    {
        //TODO
    }
}
