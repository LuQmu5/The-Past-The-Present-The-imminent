using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _movementSpeed = 4;

    [field: SerializeField] public float MaxHealth { get; set; }

    public float CurrentHealth { get; set; }

    private void Start()
    {
        _agent.speed = _movementSpeed;

        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        _agent.SetDestination(_followTarget.position);
    }

    public void ApplyDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
            gameObject.SetActive(false);
    }
}
