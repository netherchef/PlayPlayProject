using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupCheckerScript : MonoBehaviour {

	Collider2D platformCollider;

	public GameObject platform;

	private void Start () {
		platformCollider = platform.GetComponent<Collider2D> ();
	}

	private void OnTriggerExit2D (Collider2D collision) {
		if (collision.tag == "Player") CheckCollider ();
	}

	void CheckCollider () {
		if (!platformCollider.isTrigger) TurnPlatformOff ();
	}

	void TurnPlatformOff () {
		print ("GOTCHA!");
		platformCollider.isTrigger = true;
	}
}
