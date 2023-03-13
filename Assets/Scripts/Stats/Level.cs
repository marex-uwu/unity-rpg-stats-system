using System;
using UnityEngine;

[System.Serializable]
public class Level
{
    public const float BASE_EXPERIENCE_NEEDED = 50f;
    public event EventHandler OnLevelUp;
    public event EventHandler OnExperienceGained;
    public int experience
    {
        get { return _experience; }
        set
        {
            _experience = value + Mathf.RoundToInt(value * experienceMultiplier);
            while (_experience >= experienceNeededToLevelUp)
            {
                _experience -= experienceNeededToLevelUp;
                LevelUp();
            }
            OnExperienceGained?.Invoke(this, EventArgs.Empty);
        }
    }
    public float experienceMultiplier { get; set; }
    public int value => _value;
    public int experienceNeededToLevelUp => Mathf.RoundToInt((_value * BASE_EXPERIENCE_NEEDED) + (Mathf.Pow(_value, 2f) * BASE_EXPERIENCE_NEEDED));
    private int _value = 1;
    private int _experience;
    private void LevelUp()
    {
        _value++;
        OnLevelUp?.Invoke(this, EventArgs.Empty);
    }
}