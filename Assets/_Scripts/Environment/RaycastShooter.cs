using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

public class RaycastShooter : MonoBehaviour {

	public int something;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetMouseButton(0)){
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
			RaycastHit hit = new RaycastHit();
			Physics.Raycast (ray, out hit, 10000.0f);
			if (hit.collider == null){
			}
			else{
				string cName = hit.collider.name;
				System.Text.RegularExpressions.Match toot = (Regex.Match(cName, @"\d+"));
				cName = toot.ToString();
				int poot = int.Parse (cName);
				poot = poot / 3;
				Debug.Log (poot);
				string doot = poot.ToString ();
				Application.LoadLevel (doot);
				//int num = int.Parse(cName);
				//float num2 = num/3;
			}
		}

		if (Input.GetMouseButtonDown(2)) {
			Camera.main.fieldOfView = Camera.main.fieldOfView - something;
		}
		if (Input.GetMouseButtonUp (2)) {
			Camera.main.fieldOfView = Camera.main.fieldOfView + something;
		}

	}

	
}
