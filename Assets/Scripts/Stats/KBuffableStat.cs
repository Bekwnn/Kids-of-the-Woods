using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class KBuffableStat
{
    protected float _baseValue;

    public float baseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; UpdateValue(); }
    }

    public float modifiedValue
    {
        get;
        protected set;
    }

    protected List<KStatModifier> preFlatModifiers;
    protected List<KStatModifier> additivePercModifiers;
    protected List<KStatModifier> multPercModifiers;
    protected List<KStatModifier> postFlatModifiers;

    public KBuffableStat(float value)
    {
        preFlatModifiers = new List<KStatModifier>();
        additivePercModifiers = new List<KStatModifier>();
        multPercModifiers = new List<KStatModifier>();
        postFlatModifiers = new List<KStatModifier>();

        baseValue = value;
        modifiedValue = value;
    }

    public void AddModifier(KStatModifier statBuff)
    {
        switch(statBuff.modType)
        {
            case EStatModType.PRE:
                preFlatModifiers.Add(statBuff);
                break;
            case EStatModType.ADD:
                additivePercModifiers.Add(statBuff);
                break;
            case EStatModType.MUL:
                multPercModifiers.Add(statBuff);
                break;
            case EStatModType.POST:
                postFlatModifiers.Add(statBuff);
                break;
        }
        UpdateValue();
    }

    public void RemoveModifier(KStatModifier statBuff)
    {
        switch (statBuff.modType)
        {
            case EStatModType.PRE:
                preFlatModifiers.Remove(statBuff);
                break;
            case EStatModType.ADD:
                additivePercModifiers.Remove(statBuff);
                break;
            case EStatModType.MUL:
                multPercModifiers.Remove(statBuff);
                break;
            case EStatModType.POST:
                postFlatModifiers.Remove(statBuff);
                break;
        }
        UpdateValue();
    }

    public void UpdateValue()
    {
        float sumOfPreFlat = 0;
        foreach (KStatModifier mod in preFlatModifiers)
        {
            sumOfPreFlat += mod.ModValue;
        }

        float additivePercSum = 0;
        foreach (KStatModifier mod in additivePercModifiers)
        {
            additivePercSum += mod.ModValue;
        }

        modifiedValue = (baseValue + sumOfPreFlat) * (1 + additivePercSum);

        foreach (KStatModifier mod in multPercModifiers)
        {
            modifiedValue *= 1 + mod.ModValue;
        }

        foreach (KStatModifier mod in postFlatModifiers)
        {
            modifiedValue += mod.ModValue;
        }
    }
}
