using UnityEngine;
using System.Collections;

public class KSpellCastingComponent : MonoBehaviour
{
    public KBuffableStat maxResource;
    public KBuffableStat resourceRegen;
    public bool bUsesMana;

    public bool bSpellCastingDisabled;
    public bool bPassiveSpellsDisabled;

    public void RestoreResource(float amount)
    {

    }
}
