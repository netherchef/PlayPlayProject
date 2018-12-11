using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DataInputScript : MonoBehaviour {

	// Components
	public InputField newNumInput;
	public Text saveIndicator;

	// Module Components
	public GameObject dataInputModule;
	public GameObject randomiserModule;
	public GameObject dataRemoveModule;

	// Scripts
	DataHandlerScript dHandlerScript;
	RandomiserScript randomScript;
	DataRemoveScript dRemScript;

	// Variables
	public bool inDataInputMode;
	public bool inDataRemoveMode;
	public bool randomiserActive = true;
	public int digits = 4;

	private void Start () {

		// Scripts
		dHandlerScript = GetComponent<DataHandlerScript> ();
		randomScript = GetComponent<RandomiserScript> ();
		dRemScript = GetComponent<DataRemoveScript> ();
	}

	private void Update () {

		if (Input.GetKeyDown ("n")) {

			if (!inDataInputMode && !inDataRemoveMode) {
				
				ActivateDataInput ();

				DeActivateRandomiserModule ();
				DeActivateDataRemoveModule ();
			}
		}

		if (Input.GetKeyDown ("d")) {

			if (!inDataRemoveMode && !inDataInputMode) {

				ActivateDataRemoveModule ();

				DeActivateRandomiserModule ();
				DeActivateDataInput ();
			}
		}

		if (Input.GetKeyDown ("escape")) {

			if (inDataInputMode) {

				newNumInput.text = "";
				DeActivateDataInput ();

				ActivateRandomiserModule ();

			} else if (inDataRemoveMode) {

				dRemScript.remNumInputField.text = "";
				DeActivateDataRemoveModule ();

				ActivateRandomiserModule ();
			}
		}

		if (Input.GetButtonDown ("Submit")) {

			if (inDataInputMode) {
				
				SubmitData ();

			} else if (randomiserActive) {

				randomScript.StartCoroutine ("BeginRandomiserSequence");
			}
		}
	}

	public void SubmitData () {

		bool duplicateFound = false;

		try {

			if (newNumInput.text.Length > digits || newNumInput.text.Length < digits) {

				FlashIndicator (digits + " digits please...");

			} else {

				int inputNumber = int.Parse (newNumInput.text);

				for (int i = 0; i < dHandlerScript.currList.nameNumList.Count; i++) {

					if (inputNumber == dHandlerScript.currList.nameNumList[i].trunkNumber) {

						duplicateFound = true;
					}
				}

				if (!duplicateFound) {

					AddNumberToList (inputNumber);

					dHandlerScript.CommitCurrSaveDataToFile ();

					newNumInput.text = "";

					FlashIndicator ("SAVED!");

				} else {

					FlashIndicator ("Duplicate detected!");
				}
			}

			newNumInput.ActivateInputField ();

		} catch {

			FlashIndicator ("Proper number please...");

			newNumInput.text = "";

			newNumInput.ActivateInputField ();
		}
	}

	public void FlashIndicator (string signal) {

		saveIndicator.text = signal;

		Color tempColor = saveIndicator.color;

		tempColor.a = 1;

		saveIndicator.color = tempColor;

		StartCoroutine ("fadeTextOut");
	}

	IEnumerator fadeTextOut () {

		float fadeSpeed = 2;

		bool SATISFIED = false;
		while (!SATISFIED) {

			if (saveIndicator.color.a > 0) {

				Color tempColor = saveIndicator.color;

				tempColor.a -= fadeSpeed * Time.deltaTime;

				saveIndicator.color = tempColor;

			} else {

				SATISFIED = true;
			}

			yield return null;
		}
	}

	void AddNumberToList (int num) {

		NameNum currNameNum = new NameNum ();

		currNameNum.trunkNumber = num;

		dHandlerScript.currList.nameNumList.Add (currNameNum);
	}

	void ActivateDataInput () {

		inDataInputMode = true;

		if (!dataInputModule.activeSelf) {

			dataInputModule.SetActive (true);
		}

		newNumInput.ActivateInputField ();
	}

	void DeActivateDataInput () {

		if (dataInputModule.activeSelf) {

			dataInputModule.SetActive (false);
		}

		inDataInputMode = false;
	}

	void ActivateRandomiserModule () {

		randomiserActive = true;

		randomiserModule.SetActive (true);
	}

	void DeActivateRandomiserModule () {

		randomiserModule.SetActive (false);

		randomiserActive = false;
	}

	void ActivateDataRemoveModule () {
		
		inDataRemoveMode = true;

		dataRemoveModule.SetActive (true);
	}

	void DeActivateDataRemoveModule () {

		inDataRemoveMode = false;

		dataRemoveModule.SetActive (false);
	}
}
