using UnityEngine;

public class Armour : Stat
{
    public static float effectiveness = 2f;
    public Armour(Stats stats) : base(stats)
    {
    }

    public int ReduceDamage(float damage)
    {
        return Mathf.CeilToInt(damage * (totalValue / (totalValue + damage * effectiveness)));
    }
}
