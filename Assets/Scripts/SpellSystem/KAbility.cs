using UnityEngine;
using System.Collections;

public enum ESpellCastMethod
{
    ONPRESS,
	TARGETUNIT,
	AIMED,
	DRAGAIMED
};

public abstract class KAbility : MonoBehaviour
{
    public KBuff passive;
    public ESpellCastMethod castMethod;

    public bool bHasActive;
    public bool bHasPassive;

    public float cooldown;
    public float range;
}
