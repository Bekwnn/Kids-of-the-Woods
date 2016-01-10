using UnityEngine;
using System.Collections;

/// <summary>
/// The base class for gatherable resources.
/// </summary>
public class KResource : KSelectable
{
    public float resourceLeft;

    public void OnGathered(FGatherInfo gatherInfo)
    {

    }
}
