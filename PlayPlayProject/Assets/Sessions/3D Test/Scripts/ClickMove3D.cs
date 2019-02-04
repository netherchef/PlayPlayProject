using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove3D : MonoBehaviour {

	// Components

	Transform _transform;
	Camera mainCam;

	// Scripts

	Move3D move3D;
	MousePositionGetter mousePosition;

	// Click Move Variables

	Vector3 destination;
	float gapAllow = 0.5f;

	// Enumerators

	IEnumerator checkClick;

	private void Start () {

		// Components

		_transform = transform;
		mainCam = Camera.main.GetComponent<Camera> ();

		// Scripts

		move3D = GetComponent<Move3D> ();
		mousePosition = mainCam.GetComponent<MousePositionGetter> ();

		#region Start Operations ...............................................

		checkClick = CheckClick ();
		StartCoroutine (checkClick);

		#endregion

	}

	IEnumerator CheckClick () {

		while (enabled) {

			if (Input.GetMouseButton (0)) {
				Vector3 mousePos = mousePosition.GetMousePosition ();
				destination = mousePos != new Vector3 (0, 0, 0) ? mousePos : destination;
			}

			if (destination != new Vector3 (0, 0, 0)) {
				if (NotAtDestination ()) {
					MoveToDestination (destination);
				}
			}

			yield return null;
		}
	}

	void MoveToDestination (Vector3 mousePos) {
		move3D.MoveBackForth (-Mathf.Sign (_transform.position.z - mousePos.z));
		move3D.MoveSideways (-Mathf.Sign (_transform.position.x - mousePos.x));
	}

	bool NotAtDestination () {
		return DistanceX () > gapAllow || DistanceZ () > gapAllow;
	}

	float DistanceX () {
		return Mathf.Abs (_transform.position.x - destination.x);
	}

	float DistanceZ () {
		return Mathf.Abs (_transform.position.z - destination.z);
	}
}
