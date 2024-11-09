using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _movementSpeed = 4;

    private Transform _followTarget;

    [field: SerializeField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    public static event Action Died;

    public void Init(Vector3 position, Transform player)
    {
        transform.position = position;
        _followTarget = player;
        _agent.speed = _movementSpeed;
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (_followTarget != null)
            _agent.SetDestination(_followTarget.position);
    }

    public void ApplyDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            Died?.Invoke();
        }
    }
}

