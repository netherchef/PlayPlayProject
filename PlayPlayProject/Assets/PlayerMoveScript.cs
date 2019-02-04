using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

	// Components

	Transform _transform;

	// Player Movement Variables

	float movementSpeed = 10f;

	// Enumerators

	IEnumerator playerMove;

	private void Start () {

		// Components

		_transform = transform;

		#region Start Operations ...............................................

		playerMove = PlayerMove ();
		StartCoroutine (playerMove);

		#endregion
	}

	IEnumerator PlayerMove () {

		while (enabled) {

			if (Input.GetAxisRaw ("Horizontal") != 0) {
				_transform.Translate (new Vector3 (Mathf.Sign (Input.GetAxisRaw ("Horizontal") * movementSpeed * Time.deltaTime), 0, 0));
			}

			yield return null;
		}
	}
}
