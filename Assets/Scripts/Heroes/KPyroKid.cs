using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class KPyroKid : KUnit
{
    void Awake()
    {
        jsonPath = @"C:\Users\Bekwnn2\Kids of the Woods\Assets\Config\Heroes\PyroKid.json";
        heroJsonName = "pyroKid";
        InitializeComponents();
    }

    public override void AddStructureTraits(Dictionary<string, KStructure> teamBuildings)
    {
        Debug.Log("Pyro Kid's traits added to team structures!");
    }
}
