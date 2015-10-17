using UnityEngine;
using System.Collections;

public class KSpellCastOrder : KUnitOrder
{
    protected KAbility castSpell;

    public KSpellCastOrder(KUnitAI ai, KAbility spell)
    {
        aiController = ai;
        castSpell = spell;
    }

    public override void Execute()
    {
        //TODO
    }
}
