using UnityEngine;
using System.Collections;

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
