using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _offsetRotationY = 15;

    private void Update()
    {
        RotateToMouse();
    }

    public void Move(Vector3 inputVector, bool isFiring)
    {
        Vector3 movementVector = Vector3.zero;
        float speedReduceCoeff = 1.5f;

        if (inputVector.sqrMagnitude > 0.1f)
        {
            movementVector = Camera.main.transform.TransformDirection(inputVector);
            movementVector.y = 0;
            movementVector.Normalize();

            if (isFiring == false)
            {
                speedReduceCoeff = 1;
                transform.forward = movementVector;
            }
        }

        _controller.Move((_movementSpeed / speedReduceCoeff) * movementVector * Time.deltaTime);
    }

    private void RotateToMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position); 		
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 		
        float hit = 0;
        float lookSpeed = 10;
        
        if (playerPlane.Raycast (ray, out hit))
        { 			
            Vector3 targetPoint = ray.GetPoint(hit);  			
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);  		
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime); 	
        } 
    }
}
