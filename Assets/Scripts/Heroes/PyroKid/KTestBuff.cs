using UnityEngine;
using System.Collections;

public class KTestBuff : KBuff {

    public override void OnBeingHit(FDamageInfo damageInfo)
    {
        Debug.Log("OnBeingHit called, damage is " + damageInfo.flatDamageAmount);

        FDamageInfo extraMagicDamage = new FDamageInfo();
        extraMagicDamage.flatDamageAmount = damageInfo.flatDamageAmount * 0.5f;
        extraMagicDamage.damageCause = EDamageCause.ABILITY;
        extraMagicDamage.damageType = EDamageType.MAGIC;
        extraMagicDamage.bIsNotDamageInstance = true;

        Debug.Log("Adding 50% more damage as magic: " + extraMagicDamage.flatDamageAmount);
        affectedUnit.TakeDamage(extraMagicDamage);
    }
    public override void OnBuffTick()
    {
        Debug.Log("Time remaining on Buff: " + timeRemaining);
    }

    void Update()
    {
        OnUpdate();
    }
}
