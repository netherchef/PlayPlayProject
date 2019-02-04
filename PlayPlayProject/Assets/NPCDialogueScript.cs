using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCDialogueScript : MonoBehaviour {

	// Scripts

	DialogueRunner dialogueRunner;
	public DialogueRunner player_DR;

	// NPC Dialogue Variables

	bool canTalk;

	private void Start () {

		// Scripts

		dialogueRunner = GetComponent<DialogueRunner> ();
	}

	private void Update () {
		if (Input.GetButtonDown ("Interact") && canTalk) StartConversation ("Tuesday");
	}

	#region On Triggers ________________________________________________________

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.tag == "Player") canTalk = true;
	}

	private void OnTriggerExit2D (Collider2D collision) {
		if (collision.tag == "Player") canTalk = false;
	}

	#endregion

	void Talk (string node) {
		dialogueRunner.StartDialogue (node);
	}

	void StartConversation (string node) {
		dialogueRunner.StartDialogue (node);
		player_DR.StartDialogue (node);
	}
}
