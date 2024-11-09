using System.Collections.Generic;

public enum StatNames
{
    MovementSpeed,
    AttackSpeed,
    MaxHealth,
    Damage
}

public class CharacterStats
{
    private Dictionary<StatNames, float> _statsMap;

    public CharacterStats()
    {
        _statsMap = new Dictionary<StatNames, float>()
        {
            [StatNames.MovementSpeed] = 7,
            [StatNames.AttackSpeed] = 10,
            [StatNames.MaxHealth] = 10,
            [StatNames.Damage] = 2,
        };
    }

    public float Get(StatNames name) => _statsMap[name];
    public void Increase(StatNames name, float value) => _statsMap[name] += value;
}
