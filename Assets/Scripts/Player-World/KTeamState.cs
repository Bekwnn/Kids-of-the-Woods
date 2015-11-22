using UnityEngine;
using System.Collections.Generic;

//TODO: record team-related stats during game
public struct FTeamStats
{

}

public class KTeamState : MonoBehaviour
{
    public List<KPlayerState> players;
    public KTeamBuildingManager teamBuildings;

    public void InitializeTeam()
    {
        teamBuildings.AddHeroStructures(players);
    }
}
