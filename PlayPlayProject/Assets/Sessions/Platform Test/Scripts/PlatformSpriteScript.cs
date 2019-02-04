using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpriteScript : MonoBehaviour {

	Collider2D platformCol2d;

	SpriteRenderer spriteRend;

	public GameObject platform;

	private void Start () {
		platformCol2d = platform.GetComponent<Collider2D> ();

		spriteRend = GetComponent<SpriteRenderer> ();
	}

	private void Update () {
		if (!platformCol2d.isTrigger) TurnGreen (); else TurnBack ();
	}

	void TurnGreen () {
		spriteRend.color = Color.green;
	}

	void TurnBack () {
		spriteRend.color = Color.white;
	}
}
