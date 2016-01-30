﻿using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Main class of the Feral Kid character.
/// </summary>
public class KFeralKid : KUnit
{
    void Awake()
    {
        jsonPath = @"C:\Users\Bekwnn2\Kids of the Woods\Assets\Config\Heroes\FeralKid.json";
        jsonName = "feralKid";
        Initialize();
        InitializeComponents();
    }

    public override void AddStructureTraits(Dictionary<string, KUnit> teamBuildings)
    {
        Debug.Log("Feral Kid's traits added to team buildings!");
    }
}
