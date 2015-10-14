using UnityEngine;
using System.Collections;

public enum EStatModType
{
    PRE,
    ADD,
    MUL,
    POST
};

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
