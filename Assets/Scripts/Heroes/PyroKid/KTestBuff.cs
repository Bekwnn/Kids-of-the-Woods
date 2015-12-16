using UnityEngine;
using System.Collections;

public class KTestBuff : KBuff {

    public override void OnBeingHit(FDamageInfo damageInfo)
    {
        Debug.Log("OnBeingHit called, damage is " + damageInfo.flatDamageAmount);
    }
    public override void OnBuffTick()
    {
        Debug.Log("Time remaining: " + timeRemaining);
    }

    void Update()
    {
        OnUpdate();
    }
}
