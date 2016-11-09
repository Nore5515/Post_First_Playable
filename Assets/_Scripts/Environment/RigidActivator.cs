using UnityEngine;
using System.Collections;

public class RigidActivator : MonoBehaviour {
	bool iscollide = false;
	public GameObject dedFence;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		if (iscollide == true) {
			var instantiated = Instantiate (dedFence, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), this.transform.rotation) as GameObject;
			//instantiated.transform.localScale += new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);
			Destroy(this.gameObject);

		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			iscollide = true;
		} 
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			iscollide = false;
		}
	}
	public bool isCollide(){
		return iscollide;
	}
}
