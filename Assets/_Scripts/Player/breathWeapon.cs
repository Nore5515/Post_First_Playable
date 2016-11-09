using UnityEngine;
using System.Collections;

public class breathWeapon : MonoBehaviour
{
	
	public Rigidbody projectile;
	public float fireDamage;
	public float fireTime;
	public float enemyHealth;
	public float speed;
	
	public bool isOnFire;

	public float hitForce;

	void Start ()
	{
		isOnFire = false;
	}


	void Update()
	{
		if (enemyHealth <= 0)
		{
			Destroy(gameObject);
		}
		
		if (Input.GetMouseButton (0))
		{
			Debug.Log ("fire1");
			
			isOnFire = true;

			//Rigidbody instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation) as Rigidbody;
			
			//instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
		}
		
		else
		{
			isOnFire = false;
		}
	}



	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "enemy" && !isOnFire) {
			Debug.Log ("colliderEnter");

			StartCoroutine (DoFireDamage (fireTime, 4, fireDamage)); 
		}
	}



	IEnumerator DoFireDamage (float damageDuration, int damageCount, float damageAmount)
	{
		int currentCount = 0;
		
		Debug.Log ("fireStart");
		
		while (currentCount < damageCount) {
			enemyHealth -= damageAmount;
			yield return new WaitForSeconds (damageDuration);
			currentCount++;
			yield return new WaitForSeconds (5.0f);
			Destroy (this);
		}
		
		Debug.Log ("fireStop");
	}

}