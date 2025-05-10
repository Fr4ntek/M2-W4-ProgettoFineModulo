using System;

[Serializable]
public struct Stats
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }

    public static Stats Sum(Stats s1, Stats s2)
    {
        return new Stats(s1.atk + s2.atk, 
            s1.def + s2.def, 
            s1.res + s2.res, 
            s1.spd + s2.spd,
            s1.crt + s2.crt,
            s1.aim + s2.aim,
            s1.eva + s2.eva);
    }
}

