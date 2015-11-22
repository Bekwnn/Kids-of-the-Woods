using UnityEngine;
using System.Collections.Generic;

public class KTeamBuildingManager : MonoBehaviour
{
    Dictionary<string, KStructure> buildableStructures;
    List<KStructure> livingStructures;

    public void AddHeroStructures(List<KPlayerState> playerStates)
    {
        foreach (KPlayerState player in playerStates)
        {
            player.AddHeroStructureTraits(buildableStructures);
        }
    }
}
