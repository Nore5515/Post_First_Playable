
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPCLister : MonoBehaviour {
	Rigidbody Player;
	BuildingLister buildinglister;
	public ArrayList runawayList;
	public ArrayList AttackList;
	public ArrayList totalList;
	Vector3 currentPlayerposXZ;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
		buildinglister = GameObject.FindGameObjectWithTag("Blister").GetComponent<BuildingLister> ();
		if (runawayList == null)
			runawayList = new ArrayList ();
		if (AttackList == null)
			AttackList = new ArrayList ();
		if (totalList == null)
			totalList = new ArrayList ();
	
	}

	void Update(){
		currentPlayerposXZ = new Vector3 (Player.transform.position.x, 0.0f, Player.transform.position.z);

	}
	public void AddRun(GameObject n){
		if (runawayList == null)
			runawayList = new ArrayList();
		runawayList.Add(n); 
	}
	public void AddAttack(GameObject lel){
		if (AttackList == null)
			AttackList = new ArrayList ();
		AttackList.Add (lel);
	}
	public int totalListed(){
		int total = AttackList.Count + runawayList.Count;
		return total;
	}

	public void RemoveRun(GameObject e){
		for (int xd = 0; xd < runawayList.Count; ++xd) {
			if ((GameObject)runawayList [xd] == e) {
				runawayList.RemoveAt (xd);
			}
		}
	}
	public void RemoveAttack(GameObject e){
		for (int xd = 0; xd < AttackList.Count; ++xd) {
			if ((GameObject)AttackList [xd] == e) {
				AttackList.RemoveAt (xd);
			}
		}
	}
	public void NPC_FightOrFlight(GameObject NPC, bool runAt, float fastness, float rotationSpeed){
		NPC.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
			NPC.GetComponent<Rigidbody> ().transform.rotation,
			Quaternion.LookRotation ( - NPC.GetComponent<Rigidbody> ().transform.position), 
			rotationSpeed * Time.deltaTime);
		if (runAt == true)
			NPC.GetComponent<Rigidbody> ().transform.position += NPC.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
		NPC.GetComponent<Rigidbody> ().transform.position -= NPC.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
	}
	public void NPC_IdleMove(GameObject NPC){
		NPC.GetComponent<Rigidbody> ().transform.Rotate (Vector3.up, 50.0f * Time.deltaTime);
		NPC.GetComponent<Rigidbody> ().transform.position -= NPC.GetComponent<Rigidbody> ().transform.forward * 1.0f * Time.deltaTime;
	}
	public void NPC_RunToShelter(GameObject NPC,float fastness, float rotationSpeed){
		GameObject btrans = buildinglister.runToNearestShelter(NPC.gameObject);
		if (btrans == null) {
			NPC_FightOrFlight (NPC,false,fastness,rotationSpeed);
		} else {
			NPC.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
				NPC.GetComponent<Rigidbody> ().transform.rotation,
				Quaternion.LookRotation (btrans.transform.position - NPC.GetComponent<Rigidbody> ().transform.position), 
				rotationSpeed * Time.deltaTime);
			NPC.GetComponent<Rigidbody> ().transform.position += NPC.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
		}
	}
	public void NPC_DuringWall(GameObject NPC, float fastness,float rotationSpeed){
		StartCoroutine (DelayforRA (NPC,2.0f,fastness,rotationSpeed));
	}
	IEnumerator DelayforRA(GameObject NPC, float waitTime,float fastness,float rotationSpeed){
		GameObject wtrans = buildinglister.nearestWall(NPC.gameObject);
		NPC.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
			NPC.GetComponent<Rigidbody> ().transform.rotation,
			Quaternion.LookRotation (wtrans.transform.position + NPC.GetComponent<Rigidbody> ().transform.position), 
			rotationSpeed*10.0f* Time.deltaTime);
		NPC.GetComponent<Rigidbody> ().transform.position -= NPC.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
		
		yield return new WaitForSeconds (0.0f);
	}
	
	
}
