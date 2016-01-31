using UnityEngine;
using System.Collections;

public class arrive : MonoBehaviour {
	
	void Start () 
	{
		
	}

	void Update () 
	{
		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.05f);
	}
}
