using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        if(attackElement.Equals(defender.GetWeakness()))
        {
            return true;
        }
        return false;
    }
    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement.Equals(defender.GetResistance()))
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }
        if (HasElementDisadvantage(attackElement, defender))
        {
            return 0.5f;
        }
        return 1f;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        if(Random.Range(0, 100) > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        return true;

    }

    public static bool IsCrit(int critValue)
    {
        if(Random.Range(0, 100) < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        return false;
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        int baseDamage = 0;
        int difesa = 0;

        Stats attackerStats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defenderStats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());
        
        if (Weapon.DAMAGE_TYPE.PHYSICAL.Equals(attacker.GetWeapon().GetDmgType()))
        {
            difesa = defenderStats.def;
        }
        else if (Weapon.DAMAGE_TYPE.MAGICAL.Equals(attacker.GetWeapon().GetDmgType()))
        {
            difesa = defenderStats.res;
        }

        baseDamage = attackerStats.atk - difesa;
        baseDamage = (int)Mathf.Round(baseDamage * EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender));
        if (IsCrit(attackerStats.crt)) 
        {
            baseDamage *= 2;
        }

        return baseDamage >= 0 ? baseDamage : 0;
    }
}
