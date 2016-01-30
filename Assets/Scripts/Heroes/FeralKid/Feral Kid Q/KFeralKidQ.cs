using UnityEngine;
using System.Collections;

public class KFeralKidQ : KAbility {
	
    void Start()
    {
        abilityLevel = 1;
        bHasActive = true;
        bActiveNotReady = false;
    }

    public override void CastActive(KCastParams castParams)
    {
        base.CastActive(castParams);

        GameObject abilityObj = Instantiate(active);
        abilityObj.transform.position = transform.position + new Vector3(0, 1, 0);

        KAimedAbility targettingComp = abilityObj.GetComponent<KAimedAbility>();

        targettingComp.targetLocation = castParams.targetLocation;

    }
}
