using System;

[System.Serializable]
public class ManaRegeneration : Stat
{
    private const float MANA_REGEN_PER_MIND = 0.1f;
    private float mindBonus;
    public ManaRegeneration(Stats stats) : base(stats)
    {
        stats.mind.OnChanged += Mind_OnChanged;
        CalculateTotalValue();
    }
    private void Mind_OnChanged(object sender, EventArgs e) => UpdateValues();
    protected override void CalculateTotalValue()
    {
        mindBonus = stats.mind.totalValue * MANA_REGEN_PER_MIND;
        _totalValue = _baseValue + _flatBonus + mindBonus + _baseValue * _percentageBonus;
    }
}
