using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stat Modifiers/Health Modifier")]
public class HealthModifier : ScriptableObject, IStatModifier
{
    public float amount;
    public bool isPercentage;
    public void Apply(Stats stats)
    {
        if (isPercentage)
            stats.health.percentageBonus += amount;
        else stats.health.flatBonus += amount;
    }

    public void Remove(Stats stats)
    {
        if (isPercentage)
            stats.health.percentageBonus -= amount;
        else stats.health.flatBonus -= amount;
    }
}
