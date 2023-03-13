using System;
using UnityEngine;
[System.Serializable]
public class Primary : Stat
{
    public const float MAIN_INCREASE_PER_LEVEL = 1.5f;
    public const float SECONDARY_INCREASE_PER_LEVEL = 0.8f;
    public bool isMain => stats.main == this;
    private float levelBonus;
    public Primary(Stats stats) : base(stats)
    {
        stats.level.OnLevelUp += Level_OnLevelUp;
        CalculateTotalValue();
    }

    private void Level_OnLevelUp(object sender, EventArgs e) => UpdateValues();

    protected override void CalculateTotalValue()
    {
        if (stats.main == this) levelBonus = MAIN_INCREASE_PER_LEVEL * (stats.level.value - 1);
        else levelBonus = SECONDARY_INCREASE_PER_LEVEL * (stats.level.value - 1);
        _totalValue = Mathf.RoundToInt(_baseValue + _flatBonus + levelBonus + _baseValue * _percentageBonus);
    }
}