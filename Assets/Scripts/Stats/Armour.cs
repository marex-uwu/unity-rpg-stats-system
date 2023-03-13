using UnityEngine;

public class Armour : Stat
{
    public const float DEFAULT_EFFECTIVENESS = 1f;
    private float effectiveness = 1f;
    public Armour(Stats stats) : base(stats)
    {
    }

    public int ReduceDamage(float damage)
    {
        return Mathf.RoundToInt(damage * damage / (damage + totalValue * effectiveness));
    }

    public void SetEffectiveness(float effectiveness = DEFAULT_EFFECTIVENESS) => this.effectiveness = effectiveness;
}
