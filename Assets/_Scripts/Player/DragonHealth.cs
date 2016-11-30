using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DragonHealth : MonoBehaviour {

	public float MaxDragonHealth = 100.0f;
	public float SwordDamageMultiplier = 0.5f;
	private bool SwordHit;
	private float SwordHitCounter, CurrentDragonHealth,currentDamage;

	public Slider DragonHealthSlider;

	void Start () {
		CurrentDragonHealth = MaxDragonHealth;
		SwordHitCounter = 0.0f;
	}
	void Update () {

		TakenDamage();


		DragonHealthSlider.value = CurrentDragonHealth;

		//if (CurrentDragonHealth <= 0.0f){
		//	Debug.Log ("you are ded!");
		//}
			
	}
	//
	private void SetupSlider()
	{
		//enemyHealth = GetComponent<Broken_HouseCopy> ();
		DragonHealthSlider.minValue = 0.0f;
		DragonHealthSlider.maxValue = MaxDragonHealth;
		DragonHealthSlider.wholeNumbers = false;
	}


	public void ChangeSliderValue()
	{
		DragonHealthSlider.value = CurrentDragonHealth;
	}

	
	public bool IsPlayerDead(){
		if (CurrentDragonHealth <= 0.0f)
			return true;
		else 
			return false;
	}
	
	void OnTriggerEnter (Collider other){
		if (other.tag == "shortSword")
			SwordHit = true;
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "shortSword")
			SwordHit = false;
	}
	void TakenDamage(){
		if (SwordHit == true)
			SwordHitCounter++;

		currentDamage = SwordHitCounter * SwordDamageMultiplier;
		CurrentDragonHealth = MaxDragonHealth - currentDamage;
	}
}
