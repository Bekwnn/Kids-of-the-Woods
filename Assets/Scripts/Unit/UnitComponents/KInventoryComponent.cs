using UnityEngine;
using System.Collections;

/// <summary>
/// The KUnit component which handles the unit's inventory of KItems. Includes dropping, equipping, and using.
/// </summary>
public class KInventoryComponent : KUnitComponent
{
    public KItem itemSlot1;
    public KItem itemSlot2;
    public KItem itemSlot3;
    public KItem itemSlot4;
    public KItem itemSlot5;
    public KItem itemSlot6;

    public bool bItemActivesDisabled;

    public void EquipItem()
    {
        //TODO
    }

    public KItem UnequipItem()
    {
        //TODO
        return null;
    }
}
