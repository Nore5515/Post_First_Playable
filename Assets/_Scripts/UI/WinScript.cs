using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScript : MonoBehaviour {

	Canvas winScreen;

	// Use this for initialization
	void Start () {
		winScreen = this.GetComponent<Canvas> ();
		winScreen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
