using UnityEngine;
using System.Collections.Generic;

//all status effect vars should be false by default
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
    SUMMON,    //temporary summons
    BASIC,     //buildable units and neutral monsters
    HERO,      //hero type units
    RESOURCE,  //resource nodes such as wood
    STRUCTURE  //buildings
}

/// <summary>
/// The core interface of units in the game.
/// </summary>
public class KUnit : KSelectable
{
    public KUnitAI aiController;
    public KPlayerState owningPlayer;

    //for json loading
    public string jsonPath { get; protected set; }
    public string jsonName { get; protected set; }

    public KAutoAttackComponent autoAttackComponent;
    public KDefensiveComponent defensiveComponent;
    public KMovementComponent movementComponent;
    public KInventoryComponent inventoryComponent;
    public KGatheringComponent gatheringComponent;
    public KAbilityComponent abilityComponent;
    public KBuildComponent buildComponent;
    public KLevelComponent levelComponent;
    public KResourceComponent resourceComponent;
    public Component structureComponent;

    protected List<KBuff> activeBuffs;

    virtual protected void InitializeComponents()
    {
        if (autoAttackComponent) autoAttackComponent.Initialize();
        if (defensiveComponent)  defensiveComponent.Initialize();
        if (movementComponent)   movementComponent.Initialize();
        if (inventoryComponent)  inventoryComponent.Initialize();
        if (gatheringComponent)  gatheringComponent.Initialize();
        if (abilityComponent)    abilityComponent.Initialize();
        if (buildComponent)      buildComponent.Initialize();
        if (levelComponent)      levelComponent.Initialize();
    }

    virtual protected void Initialize()
    {
        activeBuffs = new List<KBuff>();
    }

    void Reset()
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

    // ------- BUFF INTERFACE --------
    /// <summary>
    /// Applies a KBuff of the given type to a unit.
    /// </summary>
    /// <typeparam name="KBuffT">Reference to the applied buff.</typeparam>
    /// <returns></returns>
    public KBuffT ApplyBuff<KBuffT>() where KBuffT : KBuff
    {
        KBuffT newBuff = gameObject.AddComponent<KBuffT>();
        activeBuffs.Add(newBuff);
        newBuff.affectedUnit = this;
        newBuff.OnApplication();
        return newBuff;
    }

    /// <summary>
    /// Removes an active buff from the unit
    /// </summary>
    /// <param name="buff">The buff object to be removed</param>
    /// <param name="bWasDispelled">Determines whether the buff should call OnExpire or OnDispell</param>
    public void RemoveBuff(KBuff buff, bool bWasDispelled)
    {
        if (activeBuffs.Contains(buff))
        {
            activeBuffs.Remove(buff);
            //let buff destroy itself in OnExpiration/OnDispelled
            if (bWasDispelled) buff.OnDispelled();
            else               buff.OnExpiration();
        }
    }

    // should these return a bool saying whether or not to abort the action?
    public void CallAttackHitOnAllBuffs(KUnit other)
    {
        foreach (KBuff buff in activeBuffs)
        {
            buff.OnAttackHit(other);
        }
    }

    public void CallAttackSentOnAllBuffs()
    {
        foreach (KBuff buff in activeBuffs)
        {
            buff.OnAttackSent();
        }
    }

    public void CallBeingHitOnAllBuffs(FDamageInfo damageInfo)
    {
        foreach (KBuff buff in activeBuffs)
        {
            buff.OnBeingHit(damageInfo);
        }
    }

    public void CallBeingHealedOnAllBuffs(FHealInfo healInfo)
    {
        foreach (KBuff buff in activeBuffs)
        {
            buff.OnBeingHealed(healInfo);
        }
    }

    public void CallAbilitySentOnAllBuffs()
    {
        foreach (KBuff buff in activeBuffs)
        {
            buff.OnAbilitySent();
        }
    }

    public void CallAbilityHitOnAllBuffs(KUnit other)
    {
        foreach (KBuff buff in activeBuffs)
        {
            buff.OnAbilityHit(other);
        }
    }
    // ------- END BUFF INTERFACE --------

    public virtual void AddStructureTraits(Dictionary<string, KStructureComponent> teamBuildings)
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
    
    public void GatherResource(KResourceComponent target)
    {
        Debug.Log("Gathering resource");
        if (gatheringComponent != null)
        {
            gatheringComponent.GatherResource(target);
        }
    }
    
    public void AutoAttackTarget(KUnit target)
    {
        Debug.Log("Trying to attack target");
        if (autoAttackComponent != null)
        {
            autoAttackComponent.TryAttackingTarget(target);
        }
    }

    public bool IsInAttackRange(KUnit target)
    {
        if (autoAttackComponent != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < autoAttackComponent.attackRange.modifiedValue)
            {
                return true;
            }
        }
        return false;
    }

    public void MoveToLocation(Vector3 location)
    {
        //Debug.Log("Moving to: " + location.ToString());
        if (movementComponent != null)
        {
            movementComponent.MoveToLocation(location);
        }
    }

    public void StopMoving()
    {
        movementComponent.StopMoving();
    }

    public void CastAbility(KAbility ability, KCastParams castParams)
    {
        Debug.Log("Casting ability");
        if (abilityComponent != null)
        {
            abilityComponent.CastAbility(ability, castParams);
        }
    }

    public void BuildStructure(KStructureComponent structure)
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
    // ------- END ORDER INTERFACE --------
}
