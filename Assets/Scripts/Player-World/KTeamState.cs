using UnityEngine;
using System.Collections.Generic;

//TODO: record team-related stats during game
public struct FTeamStats
{

}

/// <summary>
/// The representation of a team in the game. Used when determining whether something is friend or foe. Manages team resources.
/// </summary>
public class KTeamState : MonoBehaviour
{
    public List<KPlayerState> players;
    public KTeamBuildingManager teamBuildings;

    public void InitializeTeam()
    {
        teamBuildings.AddHeroStructures(players);
    }
}
