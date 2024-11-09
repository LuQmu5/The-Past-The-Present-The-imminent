using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementVector = Vector3.zero;
        Vector3 inputVector = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));

        if (inputVector.sqrMagnitude > 0.1f)
        {
            movementVector = Camera.main.transform.TransformDirection(inputVector);
            movementVector.y = 0;
            movementVector.Normalize();

            transform.forward = movementVector; // поворот в сторону движения
        }

        _controller.Move(_movementSpeed * movementVector * Time.deltaTime);
    }
}
