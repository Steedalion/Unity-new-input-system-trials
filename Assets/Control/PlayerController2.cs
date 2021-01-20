using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
	PlayerControls controls;
	bool jump;
	Vector2 move;
	public float speed =5f;
	public float jumpForce = 500f;
	Rigidbody rb;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		controls = new PlayerControls();
		controls.Player.Move.performed += ctx =>move = ctx.ReadValue<Vector2>();
		controls.Player.Move.canceled += ctx =>move = Vector2.zero;
		controls.Player.Buttons.performed += ctx => jump=true;
		//controls.Player.Move.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
		//controls.Player.Buttons.performed += ctx => SendMessage(ctx.ToString());
		
	}
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		controls.Player.Enable();
	}
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		controls.Player.Disable();
	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	protected void FixedUpdate()
	{
		Vector3 movement = new Vector3(move.x,0, move.y) * speed * Time.deltaTime;
		transform.Translate(movement, Space.World);
		Jump();
	}
	
	void Jump()
	{
		if(jump){
			rb.AddForce(transform.up * jumpForce);
			jump = false;
		}
	}
	
	//void SendMessage(string message)
	//{
	//	Debug.Log("Button pressed");
	//}
	void SendMessage(Vector2 coordinates)
	{
		Debug.Log("Thumb-stick coordinates = " + coordinates);
	}
}
