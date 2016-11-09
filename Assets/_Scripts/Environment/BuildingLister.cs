using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BuildingLister : MonoBehaviour { 
	public ArrayList buildinglist;
	public ArrayList iscloselist;
	public ArrayList isDissTrack;
	public ArrayList wallList;
	public ArrayList wallBLister;
	//^this creates a list of wall colliders	//this creates a list of wall colliders
	void Start () {
		if (buildinglist == null)
			buildinglist = new ArrayList ();
		if (iscloselist == null)
			iscloselist = new ArrayList ();
		if (isDissTrack == null)
			isDissTrack = new ArrayList ();
		if (wallList == null)
			wallList = new ArrayList ();
		if (wallBLister == null)
			wallBLister = new ArrayList ();
	}
	public void Addbuilding(GameObject n){
		if (buildinglist == null)
			buildinglist = new ArrayList();
		buildinglist.Add(n); 
	}
	public void AddTriggered(bool lel){
		if (iscloselist == null)
			iscloselist = new ArrayList ();
		iscloselist.Add (lel);
	}
	public void AddDissTrack(bool meem){
		if (isDissTrack == null)
			isDissTrack = new ArrayList ();
		isDissTrack.Add (meem);
	}
	public int BuildingNum(){
		return buildinglist.Count;
	}
	public void AddWall(GameObject wall){
		if (wallList == null)
			wallList = new ArrayList ();
		wallList.Add (wall);
	}
	public void AddWallCollider(bool iswall){
		if (wallBLister == null)
			wallBLister = new ArrayList ();
		wallBLister.Add (iswall);
	}
	public void RemoveBuilding(GameObject e){
		for (int xd = 0; xd < buildinglist.Count; ++xd) {
			if ((GameObject)buildinglist [xd] == e) {
				buildinglist.RemoveAt (xd);
			}
		}
	}
	public void RemoveTriggered(GameObject e){
		for (int xd = 0; xd < buildinglist.Count; ++xd) {
			if ((GameObject)buildinglist [xd] == e) {
				iscloselist.RemoveAt (xd);
			}
		}
	}
	public void ChangeStatusB(GameObject n, bool lel){
		for (int xd = 0; xd < buildinglist.Count; ++xd) {
			if ((GameObject)buildinglist [xd] == n) {
				iscloselist[xd] = lel;
			}
		}
	}
	public void ChangeStatusD(GameObject n, bool lel){
		//this is where the error is at!!!!! (9/28/16)
		//!!!!
		//!!!!
		for (int xd = 0; xd < buildinglist.Count; ++xd) {
			if ((GameObject)buildinglist [xd] == n) {
				isDissTrack[xd] = lel;
			}
			//else{
			//	break;
			//}
		}
	}
	public void CurrentWallCollider(GameObject sus, bool ayydabs){
		for (int s = 0; s < wallBLister.Count; ++s) {
			if((GameObject)wallList [s] == sus) {
				wallBLister[s] = ayydabs;
				//Debug.Log (ayydabs);
			}
		}
	}
	public bool IsItDestroyTho(GameObject dabs){
		for (int xd = 0; xd < buildinglist.Count; ++xd) {
			if ((GameObject)buildinglist [xd] == dabs) {
				return (bool)isDissTrack[xd];
			}
		}
		return false;
	}
	public GameObject nearestWall(GameObject runsAway){
		float smallestD = 100000;
		GameObject wallis = null;
		for(int p = 0; p < wallList.Count; ++p){
			GameObject Wilted =(GameObject) wallList[p];
			float d = Vector3.Distance(runsAway.GetComponent<Rigidbody> ().transform.position, Wilted.GetComponent<Rigidbody>().transform.position);
			if(d < smallestD){
				smallestD = d;
				wallis = Wilted;
			}
		}
		return wallis;
	}
	public bool isrunawayclose2wall(GameObject runsAway){
		float smallestD = 100000;
		bool iswelldere = false;
		GameObject wallis = null;
		for(int p = 0; p < wallList.Count; ++p){
			GameObject Wilted =(GameObject) wallList[p];
			float d = Vector3.Distance(runsAway.GetComponent<Rigidbody> ().transform.position, Wilted.GetComponent<Rigidbody>().transform.position);
			if(d < smallestD){
				smallestD = d;
				wallis = Wilted;
			}
		}
		for (int xd = 0; xd < wallList.Count; ++xd) {
			if( wallis == (GameObject) wallList[xd]){
				iswelldere = (bool)wallBLister[xd];
			}
		}
		return iswelldere;
	}
	public GameObject runToNearestShelter(GameObject runnsAway){
		float smallestD = 100000;
		GameObject buildingis = null;
			for(int p = 0; p < buildinglist.Count; ++p){
				GameObject Blisted =(GameObject) buildinglist[p];
				float d = Vector3.Distance(runnsAway.GetComponent<Rigidbody> ().transform.position, Blisted.GetComponent<Rigidbody>().transform.position);
				if(d < smallestD){
					smallestD = d;
					buildingis = Blisted;
				}
			}
		return buildingis;
	}
	public bool RULying(GameObject runnsAway){
		//float smallestD = 100000;
		bool isitalie = false;
		GameObject buildingis = null;
		if (buildinglist == null) {
			return true;
		}
		buildingis = runToNearestShelter (runnsAway);

		for (int xd = 0; xd < buildinglist.Count; ++xd) {
			if( buildingis == (GameObject) buildinglist[xd]){
				isitalie = (bool)iscloselist[xd];
			}
		}
		//Debug.Log ("am I lying?: " + isitalie);
		return isitalie;

	}
}
