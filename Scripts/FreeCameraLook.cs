﻿using UnityEngine;
using UnityEngine.Networking;



public class FreeCameraLook : Pivot {

	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float turnSpeed = 1.5f;
	[SerializeField] private float turnsmoothing = 0.1f;
	[SerializeField] private float tiltMax = 75f;
	[SerializeField] private float tiltMin = 45f;



	private float lookAngle;
	private float tiltAngle;

	private const float lookDistance = 100f;

	private float smoothX = 0;
	private float smoothY = 0;
	private float smoothXvelocity = 0;
	private float smoothYvelocity = 0;

	protected override void Awake()
	{
		base.Awake ();

		 Cursor.visible = false;
		 Cursor.lockState = CursorLockMode.Locked;

		cam = GetComponentInChildren<Camera>().transform;
		pivot = cam.parent;
	}
		
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update ();

		HandleRotationMovement();

	
	}



	protected override void Follow (float deltaTime)
	{
		transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);

	}
	void HandleRotationMovement()
	{
		float x = Input.GetAxis ("Mouse X");
		float y = Input.GetAxis ("Mouse Y");

		if (turnsmoothing > 0) {
			smoothX = Mathf.SmoothDamp (smoothX, x, ref smoothXvelocity, turnsmoothing);
			smoothY = Mathf.SmoothDamp (smoothY, y, ref smoothYvelocity, turnsmoothing);

		} 
		else 
		{
			smoothX = x;
			smoothY = y;
		}

		lookAngle += smoothX * turnSpeed;

		transform.rotation = Quaternion.Euler (0f, lookAngle, 0);

		tiltAngle -= smoothY * turnSpeed;

		tiltAngle = Mathf.Clamp (tiltAngle, - tiltMin, tiltMax);

		pivot.localRotation = Quaternion.Euler (tiltAngle, 0, 0);
	}
}
