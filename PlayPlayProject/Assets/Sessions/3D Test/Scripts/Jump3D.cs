using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump3D : MonoBehaviour {

	// Jump Variables

	public float jumpForce;

	public void Jump (Rigidbody rb) {
		rb.AddForce (new Vector3 (0, jumpForce, 0));
	}
}
