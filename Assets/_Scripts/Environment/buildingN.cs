using UnityEngine;
using System.Collections;

public class buildingN : MonoBehaviour {
	BuildingLister buildingl;
	public GameObject dedHouse;
	public ParticleSystem bom;
	//Infeltration infeldread;
	private bool iscollide = false;
	private bool arrowCollides = false;
	int counter = 0;
	// Use this for initialization
	void Start () {
		buildingl = GameObject.FindGameObjectWithTag ("Blister").GetComponent<BuildingLister> ();
		buildingl.Addbuilding (this.gameObject);
	}
	//READ THIS!!!- on shelter(the thing with the box collider) have the player destroy the entire building if shelder is collided,then remove that building, shelter, and infeltrated objects
	//from their respective lists
	void Update () {
		//Debug.Log ("is it destroy tho:"+buildingl.IsItDestroyTho(this.gameObject));
		if(buildingl.IsItDestroyTho(this.gameObject) == true||arrowCollides == true){
			//Instantiate (dedHouse, new Vector3(this.transform.position.x,this.transform.position.y+1.0f,this.transform.position.z), this.transform.rotation);
			//^here you instantiate debre
			buildingl.RemoveBuilding (this.gameObject);
			Instantiate (bom, this.transform.position, this.transform.rotation);
			//Debug.Log ("Building: "+this.gameObject+" is being deleted");
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			this.iscollide = true;
		} 
		if (other.gameObject.CompareTag ("PlayerArrow")) {
			if (counter == 100) {
				this.arrowCollides = true;
			}
			counter++;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			this.iscollide = false;
		}
		if (other.gameObject.CompareTag ("PlayerArrow")) {
			this.arrowCollides = false;
		}
	}
	public bool isCollide(){
		return this.iscollide; 
	}
	public bool arrowisCollide(){

		return this.arrowCollides;
	}
}
