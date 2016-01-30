using UnityEngine;
using System.Collections;

public class friend : MonoBehaviour
{
	public GameObject followingObject;
	public float speed;
	public float radius;
	public Vector2 velocity;
	public Sprite[] friendSprites;
	public int friendNum;
	Vector3 lastFramePos;
	float speedLimit;
	
	void Start()
	{
		speedLimit = GameObject.FindWithTag ("Player").GetComponent<player> ().defaultSpeed;
	}

	void Update()
	{
		if (followingObject != null)
		{
			if (Vector2.Distance(followingObject.transform.position, transform.position) >= radius)
				transform.position = Vector2.MoveTowards (transform.position, followingObject.transform.position, speed * Time.deltaTime);
		}

		velocity = transform.position - lastFramePos;
		lastFramePos = transform.position;

		if (velocity.y > speedLimit)
		{
			// UP
			GetComponent<SpriteRenderer>().sprite = friendSprites[0];
			GetComponent<SpriteRenderer>().sortingOrder = friendNum;
		}
		else if (velocity.y < -speedLimit)
		{
			// DOWN
			GetComponent<SpriteRenderer>().sprite = friendSprites[1];
			GetComponent<SpriteRenderer>().sortingOrder = 8 - friendNum;
		}

		if (velocity.x < -speedLimit)
		{
			// RIGHT
			GetComponent<SpriteRenderer>().sprite = friendSprites[2];
		}
		else if (velocity.x > speedLimit)
		{
			// LEFT
			GetComponent<SpriteRenderer>().sprite = friendSprites[3];
		}
	}
}
