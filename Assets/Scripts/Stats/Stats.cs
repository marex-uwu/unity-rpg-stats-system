using UnityEngine;
using System.Reflection;

[System.Serializable]
public class Stats
{
    [field: SerializeField] public Level level { get; private set; }
    [field: SerializeField] public Primary main { get; private set; }
    [field: SerializeField] public Primary might { get; private set; }
    [field: SerializeField] public Primary skill { get; private set; }
    [field: SerializeField] public Primary mind { get; private set; }
    [field: SerializeField] public Health health { get; private set; }
    [field: SerializeField] public Mana mana { get; private set; }
    [field: SerializeField] public Resource ward { get; private set; }
    [field: SerializeField] public Stat moveSpeed { get; private set; }
    [field: SerializeField] public Stat attackSpeed { get; private set; }
    [field: SerializeField] public Crit crit { get; private set; }
    [field: SerializeField] public Armour armour { get; private set; }
    [field: SerializeField] public Resource block { get; private set; }
    [field: SerializeField] public Dodge dodge { get; private set; }
    [field: SerializeField] public Stat damageIncrease { get; private set; }
    [field: SerializeField] public Stat healthRegeneration { get; private set; }
    [field: SerializeField] public ManaRegeneration manaRegeneration { get; private set; }

    private MultiSet<IStatModifier> modifiers = new();
    private MultiSet<string> flags = new();
    public Stats()
    {
        level = new Level();

        might = new Primary(this);
        skill = new Primary(this);
        mind = new Primary(this);

        health = new Health(this);
        mana = new Mana(this);
        ward = new Resource(this);
        block = new Resource(this);

        moveSpeed = new Stat(this);
        attackSpeed = new Stat(this);
        crit = new Crit(this);
        armour = new Armour(this);
        dodge = new Dodge(this);
        damageIncrease = new Stat(this);
        healthRegeneration = new Stat(this);
        manaRegeneration = new ManaRegeneration(this);
    }
    public void AddModifier(IStatModifier modifier)
    {
        modifiers.Add(modifier);
        modifier.Apply(this);
    }
    public void RemoveModifier(IStatModifier modifier)
    {
        modifiers.Remove(modifier);
        modifier.Remove(this);
    }
    public void AddFlag(string flag) => flags.Add(flag);
    public void RemoveFlag(string flag) => flags.Remove(flag);
    public bool HasFlag(string flag) => flags.Contains(flag);
    public void SetMain(Primary primary)
    {
        main = primary;
        might.UpdateValues();
        skill.UpdateValues();
        mind.UpdateValues();
    }
    public void DebugLogStats()
    {
        Debug.Log($"Level: {level.value}");
        var properties = typeof(Stats).GetProperties();
        foreach (var property in properties)
        {
            if (typeof(Stat).IsAssignableFrom(property.PropertyType))
            {
                var stat = (Stat)property.GetValue(this);

                if (stat is Resource resource)
                {
                    Debug.Log($"{property.Name}: Base Value = {resource.baseValue} - Total Value = {resource.currentValue}/{resource.totalValue} ({resource.percentage * 100f}%)");
                }
                else
                {
                    if (stat is Primary primary)
                    {
                        Debug.Log($"{property.Name}: Base Value = {primary.baseValue} - Total Value = {primary.totalValue} - Is Main = {primary.isMain}");
                    }
                    else
                    {
                        Debug.Log($"{property.Name}: Base Value = {stat.baseValue} - Total Value = {stat.totalValue}");
                    }
                }
            }
        }
    }
}
