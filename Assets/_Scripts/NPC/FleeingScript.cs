using UnityEngine;
using System.Collections;

public class FleeingScript : MonoBehaviour {
	BuildingLister buildinglister;
	NPCLister npclister;
	EnemyHealth thishealth;
	private bool isclose = false;
	private bool isinfeltrated = false;
	private bool close2wall = false;
	public float fastness = 5.0f;
	public float rotationSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		thishealth = this.GetComponent<EnemyHealth>();
		buildinglister = GameObject.FindGameObjectWithTag("Blister").GetComponent<BuildingLister> ();
		npclister = GameObject.FindGameObjectWithTag ("NPCLister").GetComponent<NPCLister> ();
		npclister.AddRun (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		isinfeltrated = buildinglister.RULying(this.gameObject);
		//Debug.Log ("is it infeltrated?: " + isinfeltrated);
		close2wall = buildinglister.isrunawayclose2wall(this.gameObject);
		TheDistancefromThing();
		if(isclose == true) {
			if (isinfeltrated == false){
				npclister.NPC_RunToShelter(this.gameObject,fastness,rotationSpeed);
			}
			else if(isinfeltrated == true){
				npclister.NPC_FightOrFlight(this.gameObject,false,fastness,rotationSpeed);
			}
			else if(isinfeltrated == null){
				npclister.NPC_FightOrFlight(this.gameObject,false,fastness,rotationSpeed);
			}
		}else
		if (isclose == false){
			npclister.NPC_IdleMove(this.gameObject);
		}
		if(close2wall == true){
			//Debug.Log ("this enemy is too close to the wall");
			npclister.NPC_DuringWall(this.gameObject,fastness,rotationSpeed);
		}
		if (thishealth.IsDead () == true) {
			npclister.RemoveRun(this.gameObject);
			Destroy (this.gameObject);
		}
	}
	void TheDistancefromThing(){
		float dist = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, this.transform.position);
		if (dist < 35.0f) {
			isclose = true;
		} else {
			isclose = false;
		}
	}
}
