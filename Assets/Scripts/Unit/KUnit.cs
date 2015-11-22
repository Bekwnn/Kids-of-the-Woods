using UnityEngine;
using System.Collections.Generic;

//for most units, all are false
public struct FUnitStatus
{
    public bool bMoveDisabled;
    public bool bTurnDisabled;
    public bool bAttackDisabled;
    public bool bCastSpellsDisabled;
    public bool bPassiveSpellsDisabled;
    public bool bItemActivesDisabled;
    public bool bFlyingMovement;
}

public class KUnit : KSelectable
{
    public KUnitAI aiController;
    public KPlayerState owningPlayer;

    public KAutoAttackComponent autoAttackComponent;
    public KDefensiveComponent defensiveComponent;
    public KMovementComponent movementComponent;
    public KInventoryComponent inventoryComponent;
    public KGatheringComponent gatheringComponent;
    public KSpellCastingComponent spellComponent;
    public KLevelComponent levelComponent;

    protected List<KBuff> activeBuffs;

    public void RegisterBuff(KBuff buff)
    {
        activeBuffs.Add(buff);
    }

    public void CallEventOnAllBuffs(EBuffEvent eventType, KUnit other = null)
    {
        switch (eventType)
        {
            case EBuffEvent.ATTACKHIT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnAttackHit(other);
                }
                break;

            case EBuffEvent.ATTACKSENT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnAttackSent();
                }
                break;

            case EBuffEvent.BEINGHIT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnBeingHit(other);
                }
                break;

            case EBuffEvent.BEINGHITBYSPELL:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnBeingHitBySpell(other);
                }
                break;

            case EBuffEvent.SPELLSENT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnSpellSent();
                }
                break;

            case EBuffEvent.SPELLHIT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnSpellHit(other);
                }
                break;
        }
    }

    public virtual void AddStructureTraits(Dictionary<string, KStructure> teamBuildings)
    {
        //by default do nothing
        Debug.Log("Add traits.");
    }
}
