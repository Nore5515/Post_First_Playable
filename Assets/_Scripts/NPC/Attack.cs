using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// 
/// 
/// </summary>
public class Attack : MonoBehaviour {
	private bool iscollide = false;
	private bool relativeCloseness = false;
	//private bool istooclose = false;
	DragonController ayylmao;
	NPCLister npclister;
	EnemyHealth thishealth;
	//how fast to move
	public float origfastness = 1.0f;
	public float faceofffastness = 0.25f;
	public float attackfastness = 10.0f;
	float currentfastness = 1.0f;
	
	//create a gravity variable
	public float gravy = 1.0f;
	
	public float origrotationSpeed = 1.0f;
	public float attackRotSped = 10.0f;
	float currentRotSped = 1.0f;
	
	//private Vector3 moveDirection = Vector3.zero;
	
	//private int counter;
	private double varX;
	private double varY;
	private double varZ;
	
	// Use this for initialization
	void Start() {
		ayylmao = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonController>();
		thishealth = this.GetComponent<EnemyHealth>();
		currentfastness = origfastness;
		currentRotSped = origrotationSpeed;
		npclister = GameObject.FindGameObjectWithTag ("NPCLister").GetComponent<NPCLister> ();
		npclister.AddAttack (this.gameObject);
	}
	
	void Update() {
		TheDistancefromPlayer ();
		//Debug.Log (relativeCloseness);
		if (ayylmao == null) {
			idleMove();
		}
		if (iscollide == true) {
			MoveTowards();
			if(relativeCloseness == true){
				duringFaceOff();
			}else if(relativeCloseness == false){
				normSped();
				StopCoroutine (DelayforRA(0.0f));
				MoveTowards();
			}
		} else if (iscollide == false) {
			idleMove();
		}
		Debug.Log ("am i ded Atk: "+thishealth.IsDead ());
		if (thishealth.IsDead () == true) {
			npclister.RemoveAttack(this.gameObject);
			Destroy (this.gameObject);
		}
	}
	void TheDistancefromPlayer(){
		float dist = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, this.transform.position);
		if (dist < 35.0f) {
			iscollide = true;
		} else {
			iscollide = false;
		}
		if (dist < 4.0f) {
			relativeCloseness = true;
		} else {
			relativeCloseness = false;
		}
	}

	public float getFast(){
		//Debug.Log ("Returning fastness: " + currentfastness);
		return currentfastness;
	}
	public void setFast(float fas){
		currentfastness = fas;
	}
	public void normSped(){
		currentfastness = origfastness;
		currentRotSped = origrotationSpeed;
	}
	public void setRotSped(float sped){
		currentRotSped = sped;
	}
	void MoveTowards(){
		this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (this.GetComponent<Rigidbody> ().transform.rotation, Quaternion.LookRotation (ayylmao.transform.position - this.GetComponent<Rigidbody> ().transform.position), currentRotSped * Time.deltaTime);
		
		this.GetComponent<Rigidbody> ().transform.position += this.GetComponent<Rigidbody> ().transform.forward * currentfastness * Time.deltaTime;
	}
	void idleMove(){
		this.GetComponent<Rigidbody> ().transform.Rotate (Vector3.up, 50.0f * Time.deltaTime);
		this.GetComponent<Rigidbody> ().transform.position -= this.GetComponent<Rigidbody> ().transform.forward * 1.0f * Time.deltaTime;
	}
	void duringFaceOff(){
		TheDistancefromPlayer ();
		float tempFast = this.getFast ();
		this.setFast (0.0f);
		this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (this.GetComponent<Rigidbody> ().transform.rotation, Quaternion.LookRotation (ayylmao.transform.position - this.GetComponent<Rigidbody> ().transform.position), currentRotSped * Time.deltaTime);
		this.GetComponent<Rigidbody> ().transform.position -= this.GetComponent<Rigidbody> ().transform.right*-1* faceofffastness * Time.deltaTime;
		StartCoroutine (DelayforRA (3.0f));
		//StopCoroutine (DelayforRA(0.0f));
		if (relativeCloseness == false) {
			Debug.Log ("Stop pls!");
			normSped();
		}
	}
	//they should go foward and back
	IEnumerator DelayforRA(float waitTime){
		yield return new WaitForSeconds (waitTime);
		this.setFast (0.0f);
		this.setRotSped (attackRotSped);
		MoveTowards ();
		yield return new WaitForSeconds (0.25f);
		this.setFast (attackfastness);
		MoveTowards ();
		yield return new WaitForSeconds (0.25f);
		this.setFast (-attackfastness);
		MoveTowards ();
		yield return new WaitForSeconds (0.5f);
		this.setFast (0.0f);
		MoveTowards ();
	}
}
