using UnityEngine;
using System.Collections;

public class HubCameraRotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (1)) {
			if (Input.GetAxis ("Mouse X") < 0) {
				this.transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f));
			}
			else if (Input.GetAxis ("Mouse X") > 0) {
				this.transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
			}
		}


	}
}
