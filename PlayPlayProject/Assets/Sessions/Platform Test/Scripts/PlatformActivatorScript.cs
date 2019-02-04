using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivatorScript : MonoBehaviour {

	Collider2D col2d;

	public Transform heightCheckObject;

	private void Start () {
		col2d = GetComponent<Collider2D> ();
	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.tag == "Player") CheckPlatform (collision.gameObject);
	}

	private void OnCollisionExit2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") DisablePlatform ();
	}

	void CheckPlatform (GameObject activator) {
		if (HigherThanChecker (activator) && NegativeVelocity (activator)) EnabledPlatform ();
	}

	bool HigherThanChecker (GameObject activator) {
		return activator.transform.position.y > heightCheckObject.position.y;
	}

	bool NegativeVelocity (GameObject activator) {
		return activator.GetComponent<Rigidbody2D> ().velocity.y < 0;
	}

	void EnabledPlatform () {
		col2d.isTrigger = false;
	}

	void DisablePlatform () {
		col2d.isTrigger = true;
	}
}
