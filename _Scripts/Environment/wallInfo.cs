using UnityEngine;
using System.Collections;

public class wallInfo : MonoBehaviour {
	private bool iscollide;
	BuildingLister buildingl;
	void Start () {
		buildingl = GameObject.FindGameObjectWithTag ("Blister").GetComponent<BuildingLister> ();
		buildingl.AddWall (this.gameObject);
		buildingl.AddWallCollider(iscollide);
	}
	void Update () {
		buildingl.CurrentWallCollider (this.gameObject, iscollide);
		//Debug.Log (iscollide);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("runaway")) {
			iscollide = true;
		} 

	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("runaway")) {
			iscollide = false;
		}
	}
	public bool isCollide(){
		return iscollide;
	}
}
