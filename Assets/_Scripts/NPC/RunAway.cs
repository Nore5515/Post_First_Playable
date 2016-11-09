using UnityEngine;
using System.Collections;

public class RunAway : MonoBehaviour {

	DragonController ayylmao;
	BuildingLister buildinglister;
	buildingN isitcollidetho;
	NPCLister npclister;
	EnemyHealth thishealth;
	//wallInfo[] iswallclose;
	private bool iscollide = false;
	private bool isinfeltrated = false;
	private bool isattacked = false;
	private bool close2wall = false;
	private bool hitbearrow = false;

	//how fast to move
	public float fastness = 1.0f;
	
	//create a gravity variable

	public float rotationSpeed = 1.0f;

	private float[] distance;
	//public int maxTime;
	//int counter = 0;
	//private int time = 0;

	//public sound
	public AudioSource thegoodbunk;

	// Use this for initialization
	void Start() {
		
		ayylmao = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonController>();
		thishealth = this.GetComponent<EnemyHealth>();
		buildinglister = GameObject.FindGameObjectWithTag("Blister").GetComponent<BuildingLister> ();
		npclister = GameObject.FindGameObjectWithTag ("NPCLister").GetComponent<NPCLister> ();
		npclister.AddRun (this.gameObject);

	}
	void Update() {
		isinfeltrated = buildinglister.RULying(this.gameObject);
		//Debug.Log ("is it infeltrated?: " + isinfeltrated);
		close2wall = buildinglister.isrunawayclose2wall(this.gameObject);
		TheDistancefromPlayer();
		if(iscollide == true) {
			if (isinfeltrated == false){
				runToShelter();
			}
			else if(isinfeltrated == true){
				runAwayNow();
			}
			else if(isinfeltrated == null){
				runAwayNow();
			}
			//runAwayNow ();
		}else
		if (iscollide == false){
			idleMove();
		}
		if(close2wall == true){
			//Debug.Log ("this enemy is too close to the wall");
				duringWall ();
		}
		if (thishealth.IsDead () == true) {
			npclister.RemoveRun(this.gameObject);
			Destroy (this.gameObject);
		}
	}
	//dis iz test (10/7/16)
	void TheDistancefromPlayer(){
		float dist = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, this.transform.position);
		if (dist < 35.0f) {
			iscollide = true;
		} else {
			iscollide = false;
		}
	}
	//end test
	void  OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("close2wall")) {
			close2wall = true;
		}
		if (other.gameObject.CompareTag ("arrows")) {
			Debug.Log ("heyarrow");
			//thegoodbunk.Play ();
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (0.0f, 50.0f, 0.0f));
			hitbearrow = true;
		}

	}
	//end test
	void duringWall(){
		StartCoroutine (DelayforRA (2.0f));
	}
	IEnumerator DelayforRA(float waitTime){
		GameObject wtrans = buildinglister.nearestWall(this.gameObject);
			this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
			this.GetComponent<Rigidbody> ().transform.rotation,
			Quaternion.LookRotation (wtrans.transform.position + this.GetComponent<Rigidbody> ().transform.position), 
			rotationSpeed*10.0f* Time.deltaTime);
			this.GetComponent<Rigidbody> ().transform.position -= this.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;

		yield return new WaitForSeconds (0.0f);
	}
	void runAwayNow(){
		this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
			this.GetComponent<Rigidbody> ().transform.rotation,
			Quaternion.LookRotation (ayylmao.transform.position - this.GetComponent<Rigidbody> ().transform.position), 
			rotationSpeed * Time.deltaTime);
		this.GetComponent<Rigidbody> ().transform.position -= this.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
	}
	void runToShelter(){
		//Debug.Log ("HIDE!");
		GameObject btrans = buildinglister.runToNearestShelter(this.gameObject);
		if (btrans == null) {
			runAwayNow ();
		} else {
			this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
			this.GetComponent<Rigidbody> ().transform.rotation,
			Quaternion.LookRotation (btrans.transform.position - this.GetComponent<Rigidbody> ().transform.position), 
			rotationSpeed * Time.deltaTime);
			this.GetComponent<Rigidbody> ().transform.position += this.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
		}
	}
	void idleMove(){
		this.GetComponent<Rigidbody> ().transform.Rotate (Vector3.up, 50.0f * Time.deltaTime);
		this.GetComponent<Rigidbody> ().transform.position -= this.GetComponent<Rigidbody> ().transform.forward * 1.0f * Time.deltaTime;
	}
	bool RandomBoolean(){
		if (Random.value >= 0.5)
		{
			return true;
		}
		return false;
	}
}