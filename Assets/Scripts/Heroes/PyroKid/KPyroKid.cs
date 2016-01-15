using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The main class of the Pyro Kid character.
/// </summary>
public class KPyroKid : KUnit
{
    void Awake()
    {
        jsonPath = @"C:\Users\Bekwnn2\Kids of the Woods\Assets\Config\Heroes\PyroKid.json";
        jsonName = "pyroKid";
        Initialize();
        InitializeComponents();
    }

    public override void AddStructureTraits(Dictionary<string, KStructure> teamBuildings)
    {
        Debug.Log("Pyro Kid's traits added to team structures!");
    }
}
