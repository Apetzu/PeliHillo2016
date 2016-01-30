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
	
	void Update()
	{
		if (Vector2.Distance(followingObject.transform.position, transform.position) >= radius)
			transform.position = Vector2.MoveTowards (transform.position, followingObject.transform.position, speed * Time.deltaTime);

		velocity = transform.position - lastFramePos;
		lastFramePos = transform.position;

		if (velocity.x < 0)
		{
			// RIGHT
			GetComponent<SpriteRenderer>().sprite = friendSprites[2];
		}
		if (velocity.x > 0)
		{
			// LEFT
			GetComponent<SpriteRenderer>().sprite = friendSprites[3];
		}
		if (velocity.y > 0)
		{
			// UP
			GetComponent<SpriteRenderer>().sprite = friendSprites[0];
			GetComponent<SpriteRenderer>().sortingOrder = friendNum;
		}
		if (velocity.y < 0)
		{
			// DOWN
			GetComponent<SpriteRenderer>().sprite = friendSprites[1];
			GetComponent<SpriteRenderer>().sortingOrder = 8 - friendNum;
		}
	}
}
