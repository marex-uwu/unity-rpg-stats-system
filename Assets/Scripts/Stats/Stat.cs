
using System;

[System.Serializable]
public class Stat
{
    public EventHandler OnChanged;
    protected float _baseValue;
    protected float _totalValue;
    protected float _flatBonus;
    protected float _percentageBonus;
    protected readonly Stats stats;

    public Stat(Stats stats)
    {
        this.stats = stats;
    }

    public float baseValue
    {
        get => _baseValue;
        set
        {
            _baseValue = value;
            CalculateTotalValue();
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public virtual float totalValue => _totalValue;
    public virtual float flatBonus
    {
        get => _flatBonus;
        set
        {
            _flatBonus = value;
            CalculateTotalValue();
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public virtual float percentageBonus
    {
        get => _percentageBonus;
        set
        {
            _percentageBonus = value;
            CalculateTotalValue();
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    protected virtual void CalculateTotalValue() => _totalValue = _baseValue + _flatBonus + _baseValue * _percentageBonus;
    public virtual void UpdateValues()
    {
        CalculateTotalValue();
        OnChanged?.Invoke(this, EventArgs.Empty);
    }
}