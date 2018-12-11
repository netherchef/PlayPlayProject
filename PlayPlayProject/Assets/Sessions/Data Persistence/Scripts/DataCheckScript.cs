using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCheckScript : MonoBehaviour {

	private void Update () {
		if (Input.GetButtonDown ("Submit")) {
			print (DataScript.persistentDatasetList.datasetList[0].word);
		}
	}
}
