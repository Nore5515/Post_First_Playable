using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPCLister : MonoBehaviour {
	public ArrayList runawayList;
	public ArrayList AttackList;
	public ArrayList totalList;
	// Use this for initialization
	void Start () {
		if (runawayList == null)
			runawayList = new ArrayList ();
		if (AttackList == null)
			AttackList = new ArrayList ();
		if (totalList == null)
			totalList = new ArrayList ();
	
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
	
	
}
