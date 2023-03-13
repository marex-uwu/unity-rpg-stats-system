using UnityEngine;

[System.Serializable]
public class Dodge : Stat
{
    private const float MAX_DODGE_CHANCE = 90f;
    private const float PSEUDO_INCREASE = 0.17f;
    private const int RANDOM_RANGE_MAX = 101;
    private const float MAGIC_DODGE_EFFECTIVENESS = 0.5f;
    private float pseudo;
    public Dodge(Stats stats) : base(stats)
    {
    }

    public override float totalValue => Mathf.Min(_totalValue, MAX_DODGE_CHANCE);

    public bool Roll()
    {
        int randomValue = Random.Range(0, RANDOM_RANGE_MAX);
        bool dodged = randomValue < totalValue + totalValue * pseudo;

        if (dodged) pseudo = 0f;
        else pseudo += PSEUDO_INCREASE;

        return dodged;
    }
    public bool MagicRoll()
    {
        int randomValue = Random.Range(0, RANDOM_RANGE_MAX);
        float value = totalValue * MAGIC_DODGE_EFFECTIVENESS;
        bool dodged = randomValue < value + value * pseudo;

        if (dodged) pseudo = 0f;
        else pseudo += PSEUDO_INCREASE;

        return dodged;
    }
}