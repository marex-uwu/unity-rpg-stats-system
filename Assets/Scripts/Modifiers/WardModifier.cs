using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stat Modifiers/Ward Modifier")]
public class WardModifier : ScriptableObject, IStatModifier
{
    public float amount;
    public bool isPercentage;
    public void Apply(Stats stats)
    {
        if (isPercentage)
            stats.ward.percentageBonus += amount;
        else stats.ward.flatBonus += amount;
    }

    public void Remove(Stats stats)
    {
        if (isPercentage)
            stats.ward.percentageBonus -= amount;
        else stats.ward.flatBonus -= amount;
    }
}
