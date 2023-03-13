using System;
using UnityEngine;

[System.Serializable]
public class Resource : Stat
{
    public float percentage { get; protected set; } = 1f;
    protected float _current;
    public float currentValue
    {
        get => _current;
        set
        {
            _current = Mathf.Min(value, _totalValue);
            percentage = Mathf.Clamp(_current / _totalValue,0f,1f);
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public Resource(Stats stats) : base(stats) 
    { 
        CalculateTotalValue();
    }
    public virtual bool CanSpend(float amount) => _current >= amount;
    protected override void CalculateTotalValue()
    {
        _totalValue = _baseValue + _flatBonus + _baseValue * _percentageBonus;
        _current = _totalValue * percentage;
    }
}