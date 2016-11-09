using UnityEngine;
using System.Collections;

public class killMyself : MonoBehaviour {

	public float killTime ;
	public bool isstick;
	// Use this for initialization
	void Start () {
		StartCoroutine(please(killTime));
		//if (isstick == true) {
			//this.setFast(0.0f)
		//}
	}


	IEnumerator please(float dedTime){
		yield return new WaitForSeconds (dedTime);
		Debug.Log ("killed good");
		Destroy (this.gameObject, dedTime);
		Debug.Log ("killed succ");
	}
	//void OnTriggerEnter(Collider other){
	//	if()
	//}
}
