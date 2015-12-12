using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KFeralKid : KUnit
{
    void Awake()
    {
        jsonPath = @"C:\Users\Bekwnn2\Kids of the Woods\Assets\Config\Heroes\FeralKid.json";
        heroJsonName = "feralKid";
        InitializeComponents();
    }

    public override void AddStructureTraits(Dictionary<string, KStructure> teamBuildings)
    {
        Debug.Log("Feral Kid's traits added to team buildings!");
    }
}
