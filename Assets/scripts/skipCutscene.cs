using UnityEngine;
using System.Collections;

public class skipCutscene : MonoBehaviour {
	
	void Start () 
	{
	
	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.Space))
		{
			Application.LoadLevel ("Project1");
		}
	}
}
