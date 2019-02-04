using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCam : MonoBehaviour {

	// Linked Game Objects

	public Transform player;

	// Enumerators

	IEnumerator watch;

	private void Start () {

		#region Start Operations ...............................................

		watch = Watch ();
		StartCoroutine (watch);

		#endregion
	}

	IEnumerator Watch () {
		while (enabled) {
			LookAt (player);
			yield return null;
		}
	}

	void LookAt (Transform trans) {
		transform.LookAt (trans);
	}
}
