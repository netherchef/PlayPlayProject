using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionGetter : MonoBehaviour {

	// Components

	Camera cam;

	// Layer Mask Variables

	public LayerMask layer;

	private void Start () {

		// Components

		cam = GetComponent<Camera> ();
	}

	public Vector3 GetMousePosition () {
		
		RaycastHit hit;
		Vector3 pos = new Vector3 (0, 0, 0);

		Ray ray = cam.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity, layer)) {
			pos = hit.point;
		}

		return pos;
	}
}
