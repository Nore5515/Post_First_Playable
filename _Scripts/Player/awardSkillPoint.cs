using UnityEngine;
using System.Collections;

public class awardSkillPoint : MonoBehaviour {
	
	private expSystem spSystem;

	// Use this for initialization
	void Start () {

		spSystem = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<expSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			//spSystem.levelUp = true;
			spSystem.islevelUp();
		}
	}
}