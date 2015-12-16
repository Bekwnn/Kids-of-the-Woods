using UnityEngine;
using System.Collections.Generic;

//TODO: record game-related stats during game
public struct FGameStats
{

}

/// <summary>
/// Determines win/loss conditions. Keeps track of teams and game objectives, as well as handling game over.
/// </summary>
public class KGameState : MonoBehaviour
{
    public List<KTeamState> teams;

    public void InitializeGameState()
    {
        foreach (KTeamState team in teams)
        {
            team.InitializeTeam();
        }
    }
}
