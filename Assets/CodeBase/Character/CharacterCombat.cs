using System;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void TryShoot(float damage, float attackSpeed)
    {
        if (_weapon.IsCooling)
            return;

        _weapon.Shoot(damage, attackSpeed);
    }
}