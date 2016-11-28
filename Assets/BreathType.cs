using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BreathType : MonoBehaviour {

	Canvas breathCanvas;
	Text breathText;
	List<string> breathTypes;
	int currentBreath;

	// Use this for initialization
	void Start () {
		breathCanvas = this.gameObject.GetComponent<Canvas> ();
		Debug.Log(breathCanvas.ToString());
		breathText = breathCanvas.gameObject.transform.GetChild(0).GetComponent<Text> ();
		Debug.Log (breathText.ToString ());
		breathTypes = new List<string> ();
		currentBreath = 0;

		//Test
		string a = "Fire";
		string b = "Poison";
		string c = "Ice";
		string d = "Lightning";
		breathTypes.Add (a);
		breathTypes.Add (b);
		breathTypes.Add (c);
		breathTypes.Add (d);

		breathText.text = breathTypes[0];


		Debug.Log (breathTypes [0] + " <-- is index 0, index 1 is --> " + breathTypes [1]);
		Debug.Log (breathTypes [2] + " <-- is index 2, index 3 is --> " + breathTypes [3]);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.RightBracket) && currentBreath < breathTypes.Count - 1) {
			currentBreath++;
			breathText.text = breathTypes [currentBreath];
			Debug.Log (currentBreath);
		} else if (Input.GetKeyDown(KeyCode.LeftBracket) && currentBreath > 0){
			currentBreath--;
			breathText.text = breathTypes [currentBreath];
			Debug.Log (currentBreath);
		}

	}
}
