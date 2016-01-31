using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

	public float speedX;
	public float health = 5f;
	public float speedY;
	public float defaultSpeed = 1f;
	public float acceleration = 100f;
	public Sprite[] playerSprites;

	void Update ()
	{
		//////// Y-AXIS ////////
		if (Input.GetKey (KeyCode.W))
		{
			speedY = Mathf.MoveTowards (speedY, defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.up * speedY);
			GetComponent<SpriteRenderer>().sprite = playerSprites[0];
			GetComponent<SpriteRenderer>().sortingOrder = 0;
		}
		else if (Input.GetKey (KeyCode.S))
		{
			speedY = Mathf.MoveTowards (speedY, -defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.up * speedY);
			GetComponent<SpriteRenderer>().sprite = playerSprites[1];
			GetComponent<SpriteRenderer>().sortingOrder = 8;
		}
		else if (!Input.GetKey (KeyCode.W) && speedY < 0f)
		{
			speedY = Mathf.MoveTowards(speedY, 0f, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.up * speedY);
		}
		else if (!Input.GetKey (KeyCode.S) && speedY > 0f)
		{
			speedY = Mathf.MoveTowards(speedY, 0f, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.up * speedY);
		}


		//////// X-AXIS ////////
		if (Input.GetKey (KeyCode.A))
		{
			speedX = Mathf.MoveTowards (speedX, -defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.right * speedX);
			GetComponent<SpriteRenderer>().sprite = playerSprites[2];
		}
		else if (Input.GetKey (KeyCode.D))
		{
			speedX = Mathf.MoveTowards (speedX, defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.right * speedX);
			GetComponent<SpriteRenderer>().sprite = playerSprites[3];
		}
		else if (!Input.GetKey (KeyCode.A) && speedX < 0f)
		{
			speedX = Mathf.MoveTowards(speedX, 0f, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.right * speedX);
		}
		else if (!Input.GetKey (KeyCode.D) && speedX > 0f)
		{
			speedX = Mathf.MoveTowards(speedX, 0f, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.right * speedX);
		}

		// CLAMPING CAMERA!!!
		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -22.5f, 22.5f), Mathf.Clamp (transform.position.y, -13.2f, 13.2f));
	}
}
