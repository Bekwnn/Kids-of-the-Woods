using UnityEngine;
using System.Collections.Generic;

public class KPlayerState : MonoBehaviour
{
    public KUnit playerHero;
    public int playerTeam;

    public List<KUnit> selectedUnits;

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
}
