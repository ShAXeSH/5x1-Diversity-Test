using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour{

	Animator anim;

	Vector3 movement;

	public float Speed = 6f;

	public Quaternion newrotation;

	public float smooth = 0.05f;

	public Transform camera;

	Rigidbody PlayerRigidbody;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>(); 
		PlayerRigidbody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");

		float h = Input.GetAxis ("Horizontal");
		movemento(v,h); 
		Move (h,v);
		Turning (h, v);
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement * Speed * Time.deltaTime;

		PlayerRigidbody.MovePosition (transform.position + movement);



	}

	void Turning(float h, float v)
	{
	 
		PlayerRigidbody.rotation = Quaternion.LookRotation(new Vector3 (h, 0, v)); 
	
	}


	void movemento (float v, float h) {
		if (h != 0f || v != 0f) {

			//checking if the user pressed any keys
			rotate(v,h);

			//rotates the player in the intended direction
			anim.SetFloat ("Speed",1);

			//then move the player in that direction
		}
		else {
			anim.SetFloat ("Speed",0);

			//Stop the player if user is not pressing any key
		}


	}

	void rotate(float v,float h) {
		if (v > 0)
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+45,0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+305,0);
			}
			else
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y,0);
			}
		}
		else if (v < 0)
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+135,0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+225,0);
			}
			else {
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+180,0);
			}
		}
		else
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+90,0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+270,0);
			}
			else {
				newrotation = transform.rotation;
				 
			}
		}


		newrotation.x = 0;

		newrotation.z = 0;

		//We only want player to rotate in y axis
		transform.rotation = Quaternion.Slerp (transform.rotation,newrotation, smooth);

		//Slerp from player's current rotation to the new intended rotaion smoothly 

		if(Input.GetMouseButton(0) || Input.GetButton("Vertical")) {
			transform.rotation = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);
		} else {
			
			transform.Rotate(0,Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0);

		}

	}





}

