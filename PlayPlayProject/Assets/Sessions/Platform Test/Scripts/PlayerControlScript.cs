using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	Rigidbody2D rb2d;

	public float speed = 4;
	public float jumpForce = 5;

	private void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	private void Update () {
		if (Input.GetAxisRaw ("Horizontal") != 0) Move ();

		if (Input.GetButtonDown ("Jump")) Jump ();
	}

	void Move () {
		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0));
	}

	void Jump () {
		rb2d.AddForce (new Vector2 (0, jumpForce));
	}
}
