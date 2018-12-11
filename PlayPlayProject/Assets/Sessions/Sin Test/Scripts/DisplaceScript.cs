using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceScript : MonoBehaviour {

	public bool sin;
	public bool cos;
	public bool tan;

	void Update () {

		float displacement = 0;

		if (sin) {
			displacement = Mathf.Sin (Time.time * 4) * 4;
		} else if (cos) {
			displacement = Mathf.Cos (Time.time * 4) * 4;
		} else if (tan) {
			displacement = Mathf.Tan (Time.time * 4) * 4;
		}

		transform.position = new Vector3 (transform.position.x, displacement,transform.position.z);

	}
}
