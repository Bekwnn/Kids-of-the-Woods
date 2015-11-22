using UnityEngine;
using System.Collections.Generic;

//TODO: record game-related stats during game
public struct FGameStats
{

}

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
