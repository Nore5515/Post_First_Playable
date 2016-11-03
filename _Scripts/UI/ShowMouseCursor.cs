using UnityEngine;
using System.Collections;

public class ShowMouseCursor : MonoBehaviour 
{
    bool toggle;

	// Use this for initialization
	void Start () 
    {
       Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown("`"))
        {
            if(toggle)
            {
                Screen.lockCursor = false;
                Cursor.visible = true;
                toggle = false;
            }
            else
            {
                Screen.lockCursor = true;
                Cursor.visible = false;
                toggle = true;
            }
        }
    }
}