using System;

[System.Serializable]
public class Mana : Resource
{
    private const float MANA_PER_MIND = 1.5f;
    private float mindBonus;
    public Mana(Stats stats) : base(stats)
    {
        stats.mind.OnChanged += Mind_OnChanged;
    }

    private void Mind_OnChanged(object sender, EventArgs e) => UpdateValues();
    protected override void CalculateTotalValue()
    {
        mindBonus = stats.mind.totalValue * MANA_PER_MIND;
        _totalValue = _baseValue + _flatBonus + mindBonus + _baseValue * _percentageBonus;
        _current = _totalValue * percentage;
    }
}