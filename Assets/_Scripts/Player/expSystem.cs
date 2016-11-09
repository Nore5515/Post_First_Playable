using UnityEngine;
using System.Collections;

public class expSystem : MonoBehaviour {
	
	public float skillPoint = 1;
	public float level = 1;

	bool levelUp = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (levelUp == true)
		{
			skillPoint++;
			Debug.Log(skillPoint);

			level++;
			Debug.Log(level);

			levelUp = false;
		}
	}

	public void islevelUp ()
	{
		levelUp = true;
	}
}