using UnityEngine;
using System.Collections;

public class Infeltrated : MonoBehaviour {
	BuildingLister buildingl;
	private bool iscollide = false;
	void Start () {
		buildingl = GameObject.FindGameObjectWithTag ("Blister").GetComponent<BuildingLister> ();
		//isitremove = GameObject.FindGameObjectWithTag ("DissTroy").GetComponent<DissTroy> ();
		buildingl.AddTriggered (this.iscollide);
	}
	// Update is called once per frame
	void Update () {
		//if(IzDissTroy() == true){;
		//	Destroy(this.gameObject);
		//}
		buildingl.ChangeStatusD (buildingl.runToNearestShelter(this.gameObject), this.iscollide);

	}
	void TheDistancefromPlayer(){
		float dist = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, this.transform.position);
		if (dist < 4.0f) {
			this.iscollide = true;
		} else {
			this.iscollide = false;
		}
	}
}
