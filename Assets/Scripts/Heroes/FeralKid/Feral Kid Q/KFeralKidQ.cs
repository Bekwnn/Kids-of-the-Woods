using UnityEngine;
using System.Collections;

public class KFeralKidQ : KAbility {
	
    void Start()
    {
        abilityLevel = 1;
        bHasActive = true;
        bActiveNotReady = false;
    }
    
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) CastActive();
	}

    public override void CastActive()
    {
        base.CastActive();

        GameObject abilityObj = Instantiate(active);
        abilityObj.transform.position = transform.position + new Vector3(0, 1, 0);

        KAimedAbility targettingComp = abilityObj.GetComponent<KAimedAbility>();

        targettingComp.targetLocation = KCameraPawn.ScreenPointToGameWorld(Input.mousePosition, Camera.main) + new Vector3(0, 1, 0);

    }
}
