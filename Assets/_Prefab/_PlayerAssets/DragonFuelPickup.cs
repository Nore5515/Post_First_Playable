using UnityEngine;
using System.Collections;

public class DragonFuelPickup : MonoBehaviour 
{
	//attach this script to the fuel recharge pickup
	//add a collider set as Trigger to the fuel pickup
	//set the pickup's layer to the player

	public float respawnTime;
	public float fuelGiven;
	public MeshRenderer meshToDisappear;
	public Collider triggerToDisappear;
	public GameObject objectToDisappear;
	public AudioSource soundSource;
	public AudioClip pickUpSound;

	private float t;
	private bool pickedUp;
	private Collider d;

	void OnTriggerEnter (Collider c) 
	{
		if (c != d) 
		{
			if (soundSource != null) 
			{
				soundSource.PlayOneShot(pickUpSound);
			}
			if (meshToDisappear != null) 
			{
				meshToDisappear.enabled = false;
			}
			if (triggerToDisappear != null) 
			{
				triggerToDisappear.enabled = false;
			}
			if (objectToDisappear != null) 
			{
				objectToDisappear.SetActive (false);
			}

			DragonController Dragon;
			Dragon = c.gameObject.GetComponent <DragonController>();
			Dragon.fuelSupply += fuelGiven;

			if (Dragon.fuelSupply > Dragon.fuelSupply) 
			{
				Dragon.fuelSupply = Dragon.fuelSupply;
			}
			pickedUp = true;
			d = c;
		}
	}
		
	void Update()
	{
		if (pickedUp) 
		{
			t += Time.deltaTime;
			if (t >= respawnTime)
			{
				d = null;
				t = 0;
				pickedUp = false;

				if (meshToDisappear != null) 
				{
					meshToDisappear.enabled = true;
				}

				if (triggerToDisappear != null) 
				{
					triggerToDisappear.enabled = true;
				}

				if (objectToDisappear != null) 
				{
					objectToDisappear.SetActive(true);
				}
			}
		}
	}
}
