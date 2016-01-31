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
	public List<KBuff> teamBuffs;	//buffs which affect all members of the team

    public void InitializeTeam()
    {
        teamBuildings.AddHeroStructures(players);
    }

	public void AddTeamBuff(KBuff buff)
	{
		teamBuffs.Add(buff);
		//TODO: apply buff to all relevant units/heroes
	}

	public void RemoveTeamBuff(KBuff buff)
	{
		teamBuffs.Remove(buff);
		//TODO: remove buff from all relevant units/heroes
	}
}
