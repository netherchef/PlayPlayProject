using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper2DScript : MonoBehaviour {

	// Variables
	public float pixelsPerUnit = 32f;
	public float zoom = 240f;
	public bool usePixelScale = false;
	public float pixelScale = 4f;

	Vector3 camPos = Vector3.zero;

	public void Move (Vector3 dir) {

		ApplyZoom ();
		camPos += dir;
		AdjustCam ();
	}

	public void MoveTo (Vector3 pos) {

		ApplyZoom ();
		camPos = pos;
		AdjustCam ();
	}

	public void AdjustCam () {

		Camera.main.transform.position = new Vector3 (
			RoundToNearestPixel (camPos.x), 
			RoundToNearestPixel (camPos.y), 
			-10f
		);
	}

	public float RoundToNearestPixel (float pos) {

		float screenPixelsPerUnit = Screen.height / (Camera.main.orthographicSize * 2f);
		float pixelValue = Mathf.Round (pos * screenPixelsPerUnit);

		return pixelValue / screenPixelsPerUnit;
	}

	public void ApplyZoom () {

		if (!usePixelScale) {

			float smallestScreenDimension = GetSmallestScreenDimension ();

			pixelScale = Mathf.Clamp (Mathf.Round (smallestScreenDimension / zoom), 1, 8);
		}

		Camera.main.orthographicSize = (Screen.height / (pixelsPerUnit * pixelScale)) * 0.5f;
	}

	public float GetSmallestScreenDimension () {

		if (Screen.height < Screen.width) {
			return Screen.height;
		} else {
			return Screen.width;
		}
	}

	public Vector3 GetCamPos () {
		return camPos;
	}
}
