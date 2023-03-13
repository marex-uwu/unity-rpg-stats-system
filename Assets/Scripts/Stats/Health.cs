using System;
using UnityEngine;


[System.Serializable]
public class Health : Resource
{
    private const float HEALTH_PER_MIGHT = 5f;
    private float mightBonus;
    public override bool CanSpend(float amount) => _current > amount;
    public Health(Stats stats) : base(stats)
    {
        stats.might.OnChanged += Might_OnChanged;
    }

    private void Might_OnChanged(object sender, EventArgs e)=> UpdateValues();
    protected override void CalculateTotalValue()
    {
        mightBonus = stats.might.totalValue * HEALTH_PER_MIGHT;
        _totalValue = _baseValue + _flatBonus + mightBonus + _baseValue * _percentageBonus;
        _current = _totalValue * percentage;
    }
}