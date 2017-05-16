using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillManager : MonoBehaviour {

    private Color Healthy = new Color(0f, 1f, 0f, 25f);
    private Color Weak = new Color(1f, 1f, 0f, 25f);
    private Color Dying = new Color(1f, 0f, 0f, 25f);
    private Image healthSliderFill;
    private float playerHealth;

	// Use this for initialization
	void Start () {
        healthSliderFill = GetComponent<Image>();
        healthSliderFill.color = Healthy;
	}
	
	// Update is called once per frame
	void Update () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth;
        if (playerHealth <= 66f && playerHealth >= 33f) { healthSliderFill.color = Weak; }
        else if (playerHealth <= 33) { healthSliderFill.color = Dying; }
        else if (playerHealth > 66f) { healthSliderFill.color = Healthy; }
	}
}
