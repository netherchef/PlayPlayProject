using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandlerScript : MonoBehaviour {

	// Components
	public NameNumList currList;

	// Save Data Variables
	string fileName = "NameNumStore.json";
	string path;
	public static bool storedListLoaded;

	private void Start () {

		// Save Data Variables
		path = Application.persistentDataPath + "/" + fileName;

		if (CheckForSave ()) {
			PullDataFromFile ();
		}

	}

	#region JSON File Handing Functions ________________________________________

	public bool CheckForSave () {

		// If the specified path contains a file, return true
		bool exists = false;

		if (File.Exists (path)) {
			exists = true;
		} else {
			print ("No data file found la...");
		}

		return exists;
	}

	public void PullDataFromFile () {

		try {

			// Pull the contents of the JSON file
			string contents = File.ReadAllText (path);

			// Convert the contents from JSON, and 
			// put them in the current save file
			currList = JsonUtility.FromJson<NameNumList> (contents);

			// Signal that save data has been loaded
			storedListLoaded = true;

			print ("Stored list loaded!");

		}
		catch (System.Exception ex) {
			print ("Starting with an empty list!");
		}
	}

	public void CommitCurrSaveDataToFile () {

		// Convert recorded data to JSON
		string contents = JsonUtility.ToJson (currList, true);

		// Write JSON data to persistent file
		File.WriteAllText (path, contents);

		print ("List saved!");
	}

	#endregion
}
