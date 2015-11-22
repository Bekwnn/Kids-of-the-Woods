using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KFeralKid : KUnit
{
    public override void AddStructureTraits(Dictionary<string, KStructure> teamBuildings)
    {
        Debug.Log("Feral Kid's traits added to team buildings!");
    }
}
