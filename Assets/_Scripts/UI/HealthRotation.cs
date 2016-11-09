using UnityEngine;
using System.Collections;

public class HealthRotation : MonoBehaviour {
	
	GameObject player;
	public Camera m_Camera;
	// Use this for initialization
	//void Start () {
	//	
	//}

	void Start(){
		m_Camera = Camera.main;
	}

	public void ChangeSliderRotation()
	{
		//this.transform.rotation = new Quaternion (player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
	}
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
		                 m_Camera.transform.rotation * Vector3.up);
		
	}
}
