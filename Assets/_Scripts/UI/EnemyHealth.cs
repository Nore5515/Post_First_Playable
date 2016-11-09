using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	
	//noots:
	//USE THIS SOONER OR LATER (but not never): GetParent.GetObject (not rite: look it up online)!!!!!!
	//Try to make this script tell the main runaway gameobject to kill itself when health counter reaches zero...
	//!!Le Daily Log(as of 10/7/16):
	//Find a way to instantiate Slider enemyHealth ... for some reason, Debug.Log(enemyHealth); is giving me null...


	bool takenDamage = false;
	bool PRODamage = false;
	public float maxHealth = 100.0f;
	private float health = 100.0f;
	public float minHealth = 0.0f;
	GameObject player; 
	DragonController ayyPlay;
	GameObject Broken_HouseCopy;
	public float healthBarLength;
	public float damage = 10.0f;
	public Slider enemyHealth; 

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		ayyPlay = GameObject.FindGameObjectWithTag ("Player").GetComponent<DragonController>();
		enemyHealth.value = maxHealth;
		
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.gameObject.CompareTag("Player")) {
			// ... the player is in range.
			takenDamage = true;
		}
		if (other.gameObject.CompareTag("PlayerArrow")) {
			// ... the player is in range.
			PRODamage = true;	
		}
		
	}
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if (other.gameObject.CompareTag("Player")) {
			// ... the player is no longer in range.
			takenDamage = false;
		}
		if (other.gameObject.CompareTag("PlayerArrow")) {
			// ... the player is no longer in range.
			PRODamage = false;
		}
	}
	
	
	void takeDamage()
	{
		//Debug.Log("is being killed?: "+takenDamage);
		float isItfest = ayyPlay.GetPlayerFastness();
		if (takenDamage && isItfest >= 1.1f) {
			//Debug.Log ("ow I'm hit!");
			health = health - damage;
			takenDamage = false;
		}
		if (PRODamage) {
			//Debug.Log ("u shoot me!");
			health = health - damage;
			PRODamage = false;
		}
	}
	void Start () {
		healthBarLength = Screen.width / 6;
		
	}
	
	/*void OnGUI() {
		Vector2 targetPos;
		
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		
		GUI.Box(new Rect(targetPos.x, Screen.height - 100, 60, 20), health + "/" + maxHealth);
	}*/
	
	
	
	private void SetupSlider()
	{
		//enemyHealth = GetComponent<Broken_HouseCopy> ();
		enemyHealth.minValue = minHealth;
		enemyHealth.maxValue = maxHealth;
		enemyHealth.wholeNumbers = false;
	}
	
	
	public void ChangeSliderValue()
	{
		enemyHealth.value = health;
	}
	public bool IsDead(){
		if (health <= minHealth)
			return true;
		else 
			return false;
	}
	void Update () {
		takeDamage();
		//sliderUI.value = health;
		//Debug.Log ("enemyHealth.value b4: "+enemyHealth.value);
		enemyHealth.value = health;
		//Debug.Log ("enemyHealth.value after: "+ enemyHealth.value);
		//Debug.Log (minHealth);
		
		//if (IsDead () == true) {
			//Destroy (this.transform.parent.gameObject);
			//Destroy (this.gameObject);
		//}
	}
}