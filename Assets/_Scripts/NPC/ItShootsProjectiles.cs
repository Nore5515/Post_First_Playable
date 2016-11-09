using UnityEngine;
using System.Collections;

public class ItShootsProjectiles : MonoBehaviour {
	FPSInput ayylmao;
	ItShootsProjectiles tooclose;
	ItShootsProjectiles shootsArrows;
	public GameObject arrowPrefab;
	public Transform arrowSpawn;

	public float fastness = 1.0f;
	public float gravy = 1.0f;
	public float rotationSpeed = 1.0f;
	public int maxTime;
	private int time = 0;
	private bool iscollide = false;
	private bool Eshooting = false;
	

	// Use this for initialization
	void Start() {
		
		ayylmao = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInput>();
		tooclose = GameObject.FindGameObjectWithTag("tooclose").GetComponentInChildren<ItShootsProjectiles> ();
		//Debug.Log (tooclose);
		shootsArrows = GameObject.FindGameObjectWithTag("shootsArrows").GetComponentInChildren<ItShootsProjectiles> ();
	}
	
	void Update() {
		
		if (isCollide () == true) {
			this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (this.GetComponent<Rigidbody> ().transform.rotation, Quaternion.LookRotation (ayylmao.transform.position - this.GetComponent<Rigidbody> ().transform.position), rotationSpeed * Time.deltaTime);
			
			this.GetComponent<Rigidbody> ().transform.position -= this.GetComponent<Rigidbody> ().transform.forward * fastness * Time.deltaTime;
		} 
		//trying to make it stop moving
		//nvm
		if (isShooting () == true && time >= maxTime) {

			//StartCoroutine(timer());
			Fire();
			time = 0;
		}

		time++;
		
		//moveDirection.y -= gravy * Time.deltaTime;
		//this.GetComponent<Rigidbody> ().transform.Translate (moveDirection);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")){
			Eshooting = true;
		}
		if (other.gameObject.CompareTag("Player")){
			iscollide = true;
		}
	}
	public bool isCollide(){
		return iscollide;
	}
	public bool isShooting(){
		return Eshooting;
	}

	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var arrow = (GameObject)Instantiate(arrowPrefab,arrowSpawn.position,arrowSpawn.rotation);

		// Add velocity to the bullet
		arrow.GetComponent<Rigidbody>().velocity = arrow.transform.up * 30;
		
		// Destroy the bullet after 1 seconds
		Destroy(arrow, 2.0f);
	}
}
