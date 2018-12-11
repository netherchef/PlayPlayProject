﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

	// Scripts
	CameraHelper2DScript camHelpScript;

	// Variables
	public float moveSpeed = 0.1f;

	Vector3 randomPos = Vector3.zero;
	float randomTimer = 0f;

	private void Start () {

		// Scripts
		camHelpScript = GetComponent<CameraHelper2DScript> ();
	}

	private void Update () {

		randomTimer -= Time.deltaTime;

		if (randomTimer <= 0f) {

			randomTimer = 2f;
			randomPos = new Vector3 (
				Random.Range (-5f, 5f), 
				Random.Range (-5f, 5f), 
				transform.position.z
			);
		}

		Vector3 moveDir = (randomPos - camHelpScript.GetCamPos ()).normalized;
		camHelpScript.Move (moveDir * moveSpeed * Time.deltaTime);
	}
}
