using System;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void TryShoot()
    {
        if (_weapon.IsCooling)
            return;

        _weapon.Shoot();
    }
}