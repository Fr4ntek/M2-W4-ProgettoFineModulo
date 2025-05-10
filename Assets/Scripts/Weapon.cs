using System;
using UnityEngine;

[Serializable]
public class Weapon
{
     public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL
    }

    [SerializeField]
    private string name;

    [SerializeField]
    private DAMAGE_TYPE dmgType;

    [SerializeField]
    private ELEMENT elem;

    [SerializeField]
    private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        SetName(name);
        SetDmgType(dmgType);
        SetElem(elem);
        SetBonusStats(bonusStats);
    }

    public string GetName() => name;
    public void SetName(string name) => this.name = name;
    public DAMAGE_TYPE GetDmgType() => dmgType;
    public void SetDmgType(DAMAGE_TYPE dmgType) => this.dmgType = dmgType;
    public ELEMENT GetElem() => elem;
    public void SetElem(ELEMENT elem) => this.elem = elem;
    public Stats GetBonusStats() => bonusStats;
    public void SetBonusStats(Stats bonusStats) => this.bonusStats = bonusStats;

}
