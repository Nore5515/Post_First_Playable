using UnityEngine;
using System.Collections;

public class shelter : MonoBehaviour {
	BuildingLister buildingl;
	private bool iscollide = false;

	void Start () {
		buildingl = GameObject.FindGameObjectWithTag ("Blister").GetComponent<BuildingLister> ();
		buildingl.AddTriggered (this.iscollide);
	}
	void Update () {
		buildingl.ChangeStatusB (buildingl.runToNearestShelter(this.gameObject), this.iscollide);
		
	}
	void TheDistancefromPlayer(){
		float dist = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, this.transform.position);
		if (dist < 35.0f) {
			iscollide = true;
		} else {
			iscollide = false;
		}
	}
}
