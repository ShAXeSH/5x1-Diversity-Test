using UnityEngine;
using System.Collections;

public class kol : MonoBehaviour{
	
	Animator anim; //Animator reference as anim
	
	public Quaternion newrotation; //quaternion values
	
	public float smooth = 0.05f; //smooth in turning

	public float JumpSpeed = 100.0f; //jump
	
	public Transform camera;

	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>(); 

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		
		float h = Input.GetAxis ("Horizontal");

		float RunFast = Input.GetAxis ("Run Fast");

		float RunAtMax = Input.GetAxis ("Run At Max");

		float jump = Input.GetAxis ("Jump");

		//float rjump = Input.GetAxis ("Jump");

		movement(v,h); 
		RunningFast (RunFast);
		RunningAtMax (RunAtMax);
		Jump (jump,h,v,RunFast,RunAtMax);
		//RunningJump (rjump,h,v,RunFast,RunAtMax);

	}

	void movement (float v, float h) {
		if (h != 0f || v != 0f) {
			
			//checking if the user pressed any keys
			rotate(v,h);
			
			//rotates the player in the intended direction

			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsRunning", true);

			
			//then move the player in that direction
		}
		else {
			
			anim.SetBool ("IsIdle", true);
			anim.SetBool ("IsRunning", false);
			
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
	}

	void RunningFast (float RunFast)
	{
		if (RunFast != 0f)
		
		{
		
			anim.SetBool ("IsRunningFast", true);
		
		} 

		else 
		
		{
		
			anim.SetBool ("IsRunningFast",false);
		
		}
	}

	void RunningAtMax (float RunAtMax)
	{

		if (RunAtMax != 0f) {

			anim.SetBool ("IsRunningMax", true);

		} 

		else 
		
		{
		
			anim.SetBool ("IsRunningMax",false);

		}
	
	}

	void Jump (float jump,float h,float v,float RunAtMax,float RunFast)
	{

		if (jump != 0f && h == 0f && v == 0f && RunAtMax == 0f && RunFast == 0f )
		
		{
			anim.SetTrigger ("IsJumping");
			rb.AddForce (Vector3.up * JumpSpeed);
		}
	}

	/*void RunningJump (float rjump,float h,float v,float RunFast,float RunAtMax)
	if (rjump = 0f && h != 0f && v != 0f && RunAtMax != 0f && RunFast != 0f)
	{



	}*/

}
 
