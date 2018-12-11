using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomiserScript : MonoBehaviour {

	// Components
	public Text resultText;

	// Scripts
	DataHandlerScript dHandlerScript;
	DataRemoveScript dRemScript;

	// Variables
	public bool randomising;
	public bool resultShowing;

	string initText;
	int randomNumber;
	Color initResultCol;

	private void Start () {

		// Scripts
		dHandlerScript = GetComponent<DataHandlerScript> ();
		dRemScript = GetComponent<DataRemoveScript> ();

		// Variables
		initText = resultText.text;
		initResultCol = resultText.color;
	}

	public void BeginRandomiserSequence () {

		if (resultShowing) { resultShowing = false; }

		if (!randomising) {

			randomising = true;

			StartCoroutine ("RandomiserSequence");
		}
	}

	IEnumerator RandomiserSequence () {

		int counter = 5;

		resultText.text = counter.ToString ();

		float lastTickTime = Time.time;

		bool SATISFIED = false;
		while (!SATISFIED) {

			if (counter > 0) {
				
				if (Time.time > lastTickTime + 1) {
					
					counter -= 1;

					lastTickTime = Time.time;

					resultText.text = counter.ToString ();

				}

			} else {

				SATISFIED = true;
			}

			yield return null;
		}

		PresentRandomNumber ();

		randomising = false;
	}

	void PresentRandomNumber () {

		int numberCount = dHandlerScript.currList.nameNumList.Count;

		randomNumber = Mathf.RoundToInt (Random.Range (0, numberCount));

		NameNum resultNameNum = dHandlerScript.currList.nameNumList[randomNumber];

		resultText.text = resultNameNum.trunkNumber.ToString ();

		resultShowing = true;

		StartCoroutine ("WaitToRemoveNumber");
	}

	IEnumerator WaitToRemoveNumber () {
		
		while (resultShowing) {

			if (resultText.color.a > 0) {

				if (Input.GetButton ("Delete")) {
					
					fadeNumberOut ();

				} else {

					resultText.color = initResultCol;
				}

			} else {

				try {
					dRemScript.KillNumber (randomNumber);
				} catch {
					Debug.LogWarning ("That's not there anymore.");
				}

				resultShowing = false;

				resultText.text = initText;

				resultText.color = initResultCol;
			}

			yield return null;
		}
	}

	void fadeNumberOut () {

		float fadeSpeed = 1;

		Color tempColor = resultText.color;

		tempColor.a -= fadeSpeed * Time.deltaTime;

		resultText.color = tempColor;
	}
}
