using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCam : MonoBehaviour {

	// Linked Game Objects

	public GameObject player;

	// Components

	Transform _transform;

	// Enumerators

	IEnumerator chase;

	private void Start () {

		// Components

		_transform = transform;

		#region Start Operations ...............................................

		chase = Chase ();
		StartCoroutine (chase);

		#endregion
	}

	IEnumerator Chase () {

		// Wait for prefab instances to get ready.

		while (!PrefabHandler.instancesCreated) yield return null;

		while (enabled) {
			
			_transform.position = player.transform.position;

			yield return null;
		}
	}
}
