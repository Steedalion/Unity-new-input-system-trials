using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
	float movementX, movementY;
	public float speed = 1;
	Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
	{
		Debug.Log("P2 Awake");
	    rb = GetComponent<Rigidbody>();
    }
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	protected void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0, movementY);
		rb.AddForce(movement * speed);
	
	}
	
	private void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	
    
	
}
