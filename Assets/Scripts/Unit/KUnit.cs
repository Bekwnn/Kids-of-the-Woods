using UnityEngine;
using System.Collections.Generic;

//for most units, all are false
public struct FUnitStatus
{
    public bool bMoveDisabled;
    public bool bTurnDisabled;
    public bool bAttackDisabled;
    public bool bCastAbilitiesDisabled;
    public bool bPassiveAbilitiesDisabled;
    public bool bItemActivesDisabled;
    public bool bFlyingMovement;
}

public enum EUnitType
{
    SUMMON,
    MONSTER,
    HERO
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
    public KAbilityComponent abilityComponent;
    public KBuildComponent buildComponent;
    public KLevelComponent levelComponent;

    protected List<KBuff> activeBuffs;

    protected void Reset()
    {
        if (autoAttackComponent == null)
            autoAttackComponent = gameObject.GetComponent<KAutoAttackComponent>();
        if (defensiveComponent == null)
            defensiveComponent = gameObject.GetComponent<KDefensiveComponent>();
        if (movementComponent == null)
            movementComponent = gameObject.GetComponent<KMovementComponent>();
        if (inventoryComponent == null)
            inventoryComponent = gameObject.GetComponent<KInventoryComponent>();
        if (gatheringComponent == null)
            gatheringComponent = gameObject.GetComponent<KGatheringComponent>();
        if (abilityComponent == null)
            abilityComponent = gameObject.GetComponent<KAbilityComponent>();
        if (levelComponent == null)
            levelComponent = gameObject.GetComponent<KLevelComponent>();
    }

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

            case EBuffEvent.BEINGHITBYABILITY:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnBeingHitByAbility(other);
                }
                break;

            case EBuffEvent.ABILITYSENT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnAbilitySent();
                }
                break;

            case EBuffEvent.ABILITYHIT:
                foreach (KBuff buff in activeBuffs)
                {
                    buff.OnAbilityHit(other);
                }
                break;
        }
    }

    public virtual void AddStructureTraits(Dictionary<string, KStructure> teamBuildings)
    {
        //by default do nothing
        Debug.Log("Add traits.");
    }

    // ------- ORDER INTERFACE --------
    public void TakeDamage(FDamageInfo damageInfo)
    {
        Debug.Log("Taking damage");
        if (defensiveComponent != null)
        {
            defensiveComponent.TakeDamage(damageInfo);
        }
    }
    
    public void GatherResource(KResource target)
    {
        Debug.Log("Gathering resource");
        if (gatheringComponent != null)
        {
            gatheringComponent.GatherResource(target);
        }
    }
    
    //needs to work for structures and units (use an attackable interface?)
    public void AutoAttackTarget(KUnit target)
    {
        Debug.Log("Trying to attack target");
        if (autoAttackComponent != null)
        {
            autoAttackComponent.TryAttackingTarget(target);
        }
    }

    public void MoveToLocation(Vector3 location)
    {
        Debug.Log("Moving to: " + location.ToString());
        if (movementComponent != null)
        {
            movementComponent.MoveToLocation(location);
        }
    }

    public void CastAbility(KAbility ability)
    {
        Debug.Log("Casting ability");
        if (abilityComponent != null)
        {
            abilityComponent.CastAbility(ability);
        }
    }

    public void BuildStructure(KStructure structure)
    {
        Debug.Log("Building structure");
        if (buildComponent != null)
        {
            buildComponent.Build(structure);
        }
    }

    public void EquipItem(/*item, slot*/)
    {
        Debug.Log("Equipping item");
    }

    public void UnequipItem(/*slot*/)
    {
        Debug.Log("Unequipping item");
    }
}
