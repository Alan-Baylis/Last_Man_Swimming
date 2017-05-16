using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float currentHealth;
	public float startingHealth;
    public Slider HealthSlider;
    //public Slider Air;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 10f);
    public AudioClip playerDeath;
    private AudioSource playerAudio;

    private bool damaged;
    private bool isDead = false;
    
	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
        HealthSlider.value = startingHealth;

        playerAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("damaged = " + damaged);
        if (damaged)
        {
            //Debug.Log("Flashing");
            damageImage.color = flashColor;
            damaged = false;
        }
        else {
            //Debug.Log("Lerping, damaged = " + damaged);
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed*Time.deltaTime);
        }
        
	}

    public void TakeDamage(int amount) {

        damaged = true;        
        currentHealth -= amount;
        HealthSlider.value = currentHealth;
        playerAudio.Play();
        Debug.Log("damaged = " + amount + ", currentHealth = " + currentHealth);          

        if (currentHealth <= 0 && !isDead) {
            Debug.Log("Player is Dead!");
            Death();
        }
    }

    private void Death() {        
        playerAudio.clip = playerDeath;
        playerAudio.Play();
        isDead = true;        
    }
}
