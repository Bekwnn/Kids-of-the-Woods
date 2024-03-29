﻿using UnityEngine;
using System.Collections.Generic;

//TODO: record player-related stats during game
public struct FPlayerStats
{

}

/// <summary>
/// The state of the player. This is the main representation of the player in the game.
/// </summary>
public class KPlayerState : MonoBehaviour
{
    public KUnit playerHero;
    public KTeamState playerTeam;
    public List<KUnit> selectedUnits;
	public List<KBuff> playerBuffs;

    public void SelectUnit(KUnit selected)
    {
        selectedUnits.Add(selected);
        selected.bSelected = true;
    }

    public void DeselectAll()
    {
        foreach (KUnit unit in selectedUnits)
        {
            unit.bSelected = false;
        }
        selectedUnits.Clear();
    }

    public void AddHeroStructureTraits(Dictionary<string, KStructureComponent> teamBuildings)
    {
        playerHero.AddStructureTraits(teamBuildings);
    }

	public void AddPlayerBuff(KBuff buff)
	{
		playerBuffs.Add(buff);
		//TODO: apply buff to all relevant units/heroes
	}

	public void RemovePlayerBuff(KBuff buff)
	{
		playerBuffs.Remove(buff);
		//TODO: remove buff from all relevant units/heroes
	}
}
