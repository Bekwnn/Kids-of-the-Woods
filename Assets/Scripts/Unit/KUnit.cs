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

public class KUnit : MonoBehaviour
{
    public GameObject selectionDecal;
    public KUnitAI aiController;

    protected List<KBuff> activeBuffs;

    protected bool _bSelected;
    public bool bSelected
    {
        get
        {
            return _bSelected;
        }
        set
        {
            _bSelected = value;
            if (_bSelected)
            {
                OnSelection();
            }
            else
            {
                OnDeselection();
            }
        }
    }

    protected virtual void OnSelection()
    {
        if (selectionDecal != null)
            selectionDecal.SetActive(true);
    }

    protected virtual void OnDeselection()
    {
        if (selectionDecal != null)
            selectionDecal.SetActive(false);
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
}
