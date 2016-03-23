
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;


public abstract class FollowGoku : MonoBehaviour 
{
	[SerializeField] public Transform target;
	[SerializeField] public bool autoTargetplayer = true;

	virtual protected void Start()
	{
		if (autoTargetplayer) {
			FindTargetPlayer ();
		}
	}

	void FixedUpdate()
	{
		if (autoTargetplayer && (target == null || !target.gameObject.activeSelf)) {
			FindTargetPlayer ();
		}

		if (target != null && (target.GetComponent<Rigidbody>() != null && !target.GetComponent<Rigidbody>().isKinematic)) 
		{
			Follow (Time.deltaTime);
		}
	}

	protected abstract void Follow (float deltatime);


	public void FindTargetPlayer()
	{
	if(target == null)
	{
	GameObject targetObj = GameObject.FindGameObjectWithTag("Player");

	if(targetObj)
	{
		SetTarget(targetObj.transform);
	}
  }
}

	public virtual void SetTarget(Transform newTransform)
	{
		target = newTransform;
	}
		
	public Transform Target{get {return this.target;}}

}
