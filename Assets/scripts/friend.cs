using UnityEngine;
using System.Collections;

public class friend : MonoBehaviour
{
	public GameObject followingObject;
	public float speed;
	public float radius;
	public float nowDistance;
	
	void Update()
	{
		RaycastHit2D hit = Physics2D.Linecast (transform.position, followingObject.transform.position, 1 << followingObject.layer);

		nowDistance = hit.distance;

		if (hit.distance >= radius)
			transform.position = Vector2.MoveTowards (transform.position, followingObject.transform.position, speed * Time.deltaTime);
	}
}
