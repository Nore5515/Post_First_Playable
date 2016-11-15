using UnityEngine;
using System.Collections;

public class Minigun : MonoBehaviour {
	
	/// <summary>
	/// The minigun active.
	/// </summary>
	private bool minigunActive;
	public GameObject good;
	public int bulletSpeed;
	private int buffer;
	public int maxBuffer;
	public AudioSource pewpew;
	public GameObject source;
	public levelingMenu breathskill;

	// Use this for initialization
	void Start () {
		minigunActive = false;
		breathskill = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<levelingMenu>();
		bulletSpeed = 25;

	}
	
	// Update is called once per frame
	void Update () {

		//1 and 0 enable/disable minigun
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			minigunActive = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			minigunActive = false;
		}

		//5 and 6 increase/decrease bullet speed
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			bulletSpeed--;
			Debug.Log ("sped: " + bulletSpeed);
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			bulletSpeed++;
			Debug.Log ("sped: " + bulletSpeed);
		}

		if (breathskill.breath == 1) {
			
			//if minigun active and right click ready, make bullet and push it z + bulletspeed
			if (Input.GetMouseButton (0) /*&& minigunActive*/) {
				if (buffer == maxBuffer) {
					GameObject bullet = (GameObject)Instantiate (good, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), source.transform.rotation);
					Rigidbody rb = bullet.GetComponent<Rigidbody> ();
					rb.velocity = transform.TransformDirection (new Vector3 (0, 0, bulletSpeed));
					buffer = 0;
					//pewpew.Play ();
				} else {
					buffer++;
				}
			}
		}
	}
}
