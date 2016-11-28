using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListChecker : MonoBehaviour {
	BuildingLister buildinglister;
	NPCLister npclister;

	public Canvas winScreen;

	private expSystem spSystem;

	// Use this for initialization
	void Start () {
		buildinglister = GameObject.FindGameObjectWithTag("Blister").GetComponent<BuildingLister> ();
		npclister = GameObject.FindGameObjectWithTag ("NPCLister").GetComponent<NPCLister> ();
		spSystem = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<expSystem>();
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
	}

	public void ReturnToHub(){
		Debug.Log ("Return to hub!");
		Application.LoadLevel ("Hub");
	}

}
