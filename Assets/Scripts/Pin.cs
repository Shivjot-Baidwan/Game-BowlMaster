using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	// This code helps to find whether the pins are standing or not. We try to find this with the help of its angle. 
	//If the pins are rotated  at a certain angle, we consider them fallen.
	// This code further helps in counting the number of standing pins, and furthermore whether we need to tidy or reset all the pins.

	public float standingThreshold = 3f;
	public float distToRaise = 40f;

	private Rigidbody rigidBody;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}
	
	public bool IsStanding () {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
			return true;
		} else {
			return false;
		}
	}

	public void RaiseIfStanding () {
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
			transform.rotation = Quaternion.Euler (270f, 0, 0);
		}
	}

	public void Lower () {
		transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
		rigidBody.useGravity = true;
	}

}