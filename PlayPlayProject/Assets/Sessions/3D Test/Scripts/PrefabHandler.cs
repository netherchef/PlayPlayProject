using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHandler : MonoBehaviour {

	// Prefabs

	public static GameObject playerInstance;
	public GameObject player;

	// Instance Creation Variables

	public static bool instancesCreated;

	private void Awake () {
		instancesCreated = false;
	}

	private void Start () {

		// Prefabs

		playerInstance = player;

		instancesCreated = true;
	}
}
