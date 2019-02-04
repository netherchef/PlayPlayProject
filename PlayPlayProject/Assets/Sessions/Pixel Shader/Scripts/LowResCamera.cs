﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LowResCamera : MonoBehaviour {

	// Materials

	public Material lowResMat;

	private void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, lowResMat);
	}
}
