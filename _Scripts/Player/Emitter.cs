using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	public levelingMenu breathSkill;

	public int particlesPerSec = 100;
	public ParticleSystem fireBreath;
	
	// Use this for initialization
	void Start () 
	{
		fireBreath = GetComponent<ParticleSystem>();
		breathSkill = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<levelingMenu>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (breathSkill.breath == 1)
		{
			if (Input.GetMouseButton (0))
			{
				fireBreath.Emit((int)(particlesPerSec * Time.deltaTime));
			}
		}
	}
}