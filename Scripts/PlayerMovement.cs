using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float Speed = 6f;
	public float jumpSpeed = 5f;

	Vector3 movement;
	Animator anim;
	Rigidbody PlayerRigidbody;
	
	void Awake()
	{
		anim = GetComponent<Animator> ();
		PlayerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		float j = Input.GetAxisRaw ("Jump");

		Move (h, v);
		Animating (h, v, j);
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement * Speed * Time.deltaTime;

		PlayerRigidbody.MovePosition (transform.position + movement);


		}
	void Animating(float h, float v, float j)
	{
		bool running = h != 0f || v != 0f;

		anim.SetBool ("IsRunning", running);

		bool jumping = j != 0f;

		anim.SetBool ("IsJumping", jumping);
	}
}
