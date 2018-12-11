using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataScript : MonoBehaviour {
	
	// Components
	public static DatasetList persistentDatasetList;

	// Static Displays
	public DatasetList datasetListControl;

	private void Update () {

		if (Input.GetButtonDown ("Submit")) {
			persistentDatasetList = datasetListControl;

			if (Input.GetButtonDown ("Jump")) {
				SceneManager.LoadScene ("Data Persistence 1");
			}
		}
	}
}
