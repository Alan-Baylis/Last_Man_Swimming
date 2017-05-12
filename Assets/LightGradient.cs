using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGradient : MonoBehaviour
{
	public Light sunlight;
	public float lightScaling;
	private float depth;

	void Update ()
	{
		depth = (MainPlayerController.waterLevel - transform.position.y);
		Color depthColor = new Color ();
		// reduce reds and greens as you go lower
		depthColor [0] = (255 - depth * lightScaling) / 255;
		depthColor [1] = (255 - depth * lightScaling) / 255;
		depthColor [2] = 1;
		sunlight.color = depthColor;
	}
}
