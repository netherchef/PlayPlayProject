using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataRemoveScript : MonoBehaviour {

	// Components
	public InputField remNumInputField;

	// Scripts
	DataHandlerScript dHandlerScript;
	DataInputScript dInPutScript;

	private void Start () {

		// Scripts
		dHandlerScript = GetComponent<DataHandlerScript> ();
		dInPutScript = GetComponent<DataInputScript> ();
	}

	public void RemoveNumber () {

		try {

			bool numFound = false;

			int remNum = int.Parse (remNumInputField.text);

			for (int i = 0; i < dHandlerScript.currList.nameNumList.Count; i++) {

				if (remNum == dHandlerScript.currList.nameNumList[i].trunkNumber) {

					numFound = true;

					KillNumber (i);
				}
			}

			if (numFound) {

				dInPutScript.FlashIndicator ("BYE " + remNum + "...");

			} else {

				dInPutScript.FlashIndicator ("Don't have leh...");
			}

			dHandlerScript.CommitCurrSaveDataToFile ();

		} catch {

			dInPutScript.FlashIndicator ("Proper number please...");

			remNumInputField.text = "";
		}
	}

	public void KillNumber (int num) {
		dHandlerScript.currList.nameNumList.RemoveAt (num);
	}
}
