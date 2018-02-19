using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderController : MonoBehaviour {

	bool Action = false;
	bool isGrounded = false;

	public Rigidbody2D rb;

	public float speed = 20f;
	public float rotationSpeed = 7f;

	private void Update()
	{
	
		if (Input.GetButtonDown ("Jump")) {
		
			Action = true;
		}

		if (Input.GetButtonUp ("Jump")) {
		
			Action = false;
		}
	}

	private void FixedUpdate() 
	{
		if (Action == true) 
		{
			if (isGrounded) {	
				rb.AddForce (transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
			}
			else
			{
				rb.AddTorque (rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
			}
		}
	
	}

	private void OnCollisionEnter2D()
	{
		isGrounded = true;
	}

	private void OnCollisionExit2D()
	{
		isGrounded = false;
	}
}
