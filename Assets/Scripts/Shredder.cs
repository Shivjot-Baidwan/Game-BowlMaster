using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// This piece of code is used to destroy the objects (pins) when they fall from the floor.
	void OnTriggerExit (Collider collider) {
		GameObject thingLeft = collider.gameObject;
		
		if (thingLeft.GetComponent<Pin> ()){
			Destroy (thingLeft);
		}
	}
}