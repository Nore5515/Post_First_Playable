using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ListChecker : MonoBehaviour {
	BuildingLister buildinglister;
	NPCLister npclister;
	DragonHealth dragonhealth;
	public Canvas winScreen;
	public Canvas looseSceen;
	private expSystem spSystem;

	// Use this for initialization
	void Start () {
		buildinglister = GameObject.FindGameObjectWithTag("Blister").GetComponent<BuildingLister> ();
		npclister = GameObject.FindGameObjectWithTag ("NPCLister").GetComponent<NPCLister> ();
		spSystem = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<expSystem>();
		dragonhealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<DragonHealth> ();
		looseSceen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("number of buildings: "+buildinglister.BuildingNum ());
		Debug.Log ("number of NPC's: " + npclister.totalListed ());
		if (npclister.totalListed () == 0 && buildinglister.BuildingNum () == 0) {

			winScreen.enabled = true;

			spSystem.islevelUp();
			Debug.Log("Level Up!");
		}
		if (dragonhealth.IsPlayerDead() == true) {
			StartCoroutine (LooseDelay (1.0f,looseSceen));
		}
	}

	public void ReturnToHub(){
		Debug.Log ("Return to hub!");
		Application.LoadLevel ("Hub");
	}
	IEnumerator LooseDelay(float waitTime, Canvas looseScreen){
		looseScreen.enabled = true;
		yield return new WaitForSeconds (waitTime);
		Application.LoadLevel ("Hub");
		//looseScreen.enabled = false;
	}
}
