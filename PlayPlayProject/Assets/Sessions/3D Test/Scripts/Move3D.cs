using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour {

	// Components

	Rigidbody rb;

	// Scripts

	Jump3D jump;

	// Movement Variables

	public float moveSpeed;
	public float strafeSpeed;

	// Enumerators

	IEnumerator checkMovement;

	private void Start () {

		// Components

		rb = GetComponent<Rigidbody> ();

		// Scripts

		jump = GetComponent<Jump3D> ();

		#region Start Operations ...............................................

		checkMovement = CheckMovement ();
		StartCoroutine (checkMovement);

		#endregion
	}

	IEnumerator CheckMovement () {

		while (enabled) {

			if (Input.GetAxisRaw ("Vertical") != 0) MoveBackForth (Mathf.Sign (Input.GetAxisRaw ("Vertical")));
			if (Input.GetAxisRaw ("Horizontal") != 0) MoveSideways (Mathf.Sign (Input.GetAxisRaw ("Horizontal")));

			if (Input.GetButtonDown ("Jump")) {
				jump.Jump (rb);
			}

			yield return null;
		}
	}

	public void MoveBackForth (float direction) {
		rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, direction * moveSpeed);
	}

	public void MoveSideways (float direction) {
		rb.velocity = new Vector3 (direction * strafeSpeed, rb.velocity.y, rb.velocity.z);
	}
}
