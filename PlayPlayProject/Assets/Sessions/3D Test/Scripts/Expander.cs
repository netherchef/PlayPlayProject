using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour {

	// Linked Game Objects

	public Transform ground;

	private void OnTriggerExit (Collider other) {
		if (other.tag == "Player") Expand ();
	}

	void Expand () {
		ground.localScale *= 2;
	}
}
