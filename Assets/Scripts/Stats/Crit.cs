using System;

[System.Serializable]
public class Crit : Stat
{
    private const float CRIT_PER_SKILL = 0.1f;
    private float skillBonus;
    public Crit(Stats stats) : base(stats)
    {
        stats.skill.OnChanged += Skill_OnChanged;
        CalculateTotalValue();
    }

    private void Skill_OnChanged(object sender, EventArgs e) => UpdateValues();
    protected override void CalculateTotalValue()
    {
        skillBonus = stats.skill.totalValue * CRIT_PER_SKILL;
        _totalValue = _baseValue + _flatBonus + skillBonus + _baseValue * _percentageBonus;
    }
}