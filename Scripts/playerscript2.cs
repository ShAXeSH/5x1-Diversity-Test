using UnityEngine;
using System.Collections;

public class playerscript2 : MonoBehaviour{
	
	Animator anim;
	
	public Quaternion newrotation;
	
	public float smooth = 0.05f;
	
	public Transform camera;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		
		float h = Input.GetAxis ("Horizontal");
		movement(v,h); 
	}

	void movement (float v, float h) {
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
	}
}

