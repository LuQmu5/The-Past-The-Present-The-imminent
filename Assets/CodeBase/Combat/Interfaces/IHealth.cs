using UnityEngine;

public interface IHealth
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    public void ApplyDamage(float amount);
}