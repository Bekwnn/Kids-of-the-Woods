using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Each team has one building manager which keeps track of the team's buildings and which buildings can be built. Hero picks contribute to the types of buildings a team can build.
/// </summary>
public class KTeamBuildingManager : MonoBehaviour
{
    Dictionary<string, KUnit> buildableStructures;
    List<KUnit> livingStructures;

    public void AddHeroStructures(List<KPlayerState> playerStates)
    {
        foreach (KPlayerState player in playerStates)
        {
            player.AddHeroStructureTraits(buildableStructures);
        }
    }
}
