using UnityEngine;
using System.Collections;

public class DissTroy : MonoBehaviour {
	BuildingLister buildingl;
	private bool iscollide = false;
	void Start () {
		buildingl = GameObject.FindGameObjectWithTag ("Blister").GetComponent<BuildingLister> ();
		//isitremove = GameObject.FindGameObjectWithTag ("DissTroy").GetComponent<DissTroy> ();
		buildingl.AddDissTrack (this.iscollide);
	}
	// Update is called once per frame
	void Update () {
		//if(IzDissTroy() == true){;
		//	Destroy(this.gameObject);
		//}
		buildingl.ChangeStatusD (buildingl.runToNearestShelter(this.gameObject), this.iscollide);
	
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			this.iscollide = true;
		} 
		//Debug.Log ("Player has collided with a DissTroy");
	}
	public bool IzDissTroy (){
		return this.iscollide;
	}
}
