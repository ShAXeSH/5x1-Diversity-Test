using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float speed;

	public Text countText;

	public Text winText;

	public Text pressEscape;

	private int count;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		pressEscape.text = "";
	}


	void FixedUpdate ()
    {


		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }	

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
	}
}

void SetCountText ()
  {
		
		countText.text = "Count: " + count.ToString (); 
		if (count >= 3) {
			winText.text = "You Win!";
			}
		if (count >= 3){
			pressEscape.text = "Press [ESCAPE] to restart.";
		}
}
}
