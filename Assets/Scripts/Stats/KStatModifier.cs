using UnityEngine;
using System.Collections;

public enum EStatModType
{
    PRE,
    ADD,
    MUL,
    POST
};

/// <summary>
/// Modifies BuffableStat. Can be registered as a flat or percent modifier. Its modification value can be changed after registration (causes BuffableStat to update).
/// </summary>
public class KStatModifier
{
    protected float modValue;
    public EStatModType modType;
    public KBuffableStat currentlyModifiedStat;

    public float ModValue
    {
        get { return modValue; }
        set
        {
            modValue = value;
            if (currentlyModifiedStat != null) currentlyModifiedStat.UpdateValue();
        }
    }
}
