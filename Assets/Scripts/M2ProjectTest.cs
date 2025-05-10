using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class M2ProjectTest : MonoBehaviour
{
    public Hero hero1;
    public Hero hero2;
    private Hero first;
    private Stats firstHeroStats;
    private Hero second;
    private Stats secondHeroStats;

    Stats hero1Stats = new Stats();
    Stats hero2Stats = new Stats();

    void Start()
    {
        hero1Stats = Stats.Sum(hero1.GetBaseStats(), hero1.GetWeapon().GetBonusStats());
        hero2Stats = Stats.Sum(hero2.GetBaseStats(), hero2.GetWeapon().GetBonusStats());

        if (hero1Stats.spd > hero2Stats.spd)
        {
            first = hero1;
            second = hero2;
            firstHeroStats = hero1Stats;
            secondHeroStats = hero2Stats;
        }
        else
        {
            first = hero2;
            second = hero1;
            firstHeroStats = hero2Stats;
            secondHeroStats = hero1Stats;
        }

    }

    void Update()
    {
        if(!hero1.IsAlive() || !hero2.IsAlive())
        {
            Debug.Log("Uno dei due è morto. Il duello non può cominciare.");
            this.enabled = false;
            return;
        }

        Attack(first, second, firstHeroStats, secondHeroStats);

        if (!second.IsAlive())
        {
            Debug.Log($"Duello terminato. Il vincitore è: {first.GetName()}");
            return;
        }
        
        Attack(second, first, secondHeroStats, firstHeroStats);
        
        if (!first.IsAlive())
        {
            Debug.Log($"Duello terminato. Il vincitore è: {second.GetName()}");
            return;
        }
    }

    private void Attack(Hero attacker, Hero defender, Stats attackerStats, Stats defenderStats)
    {
        Debug.Log($"Attaccante: {attacker.GetName()} - Difensore: {defender.GetName()}");

        if (GameFormulas.HasHit(attackerStats, defenderStats))
        {
            if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log("WEAKNESS: L'attacco è superefficace.");
            }
            else
            {
                Debug.Log("RESIST: L'attacco non è molto efficace.");
            }
            int damage = GameFormulas.CalculateDamage(attacker, defender);
            Debug.Log($"Danno calcolato: {damage}");
            defender.TakeDamage(damage);
        }
    }
}
