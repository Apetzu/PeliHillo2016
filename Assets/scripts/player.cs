using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

	public float speedX;
	public float speedY;
	public float defaultSpeed = 1f;
	public float acceleration = 100f;

	void Update ()
	{
		//////// Y-AXIS ////////
		if (Input.GetKey (KeyCode.W))
		{
			speedY = Mathf.MoveTowards (speedY, defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.up * speedY);
		}
		else if (Input.GetKey (KeyCode.S))
		{
			speedY = Mathf.MoveTowards (speedY, -defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.up * speedY);
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
		}
		else if (Input.GetKey (KeyCode.D))
		{
			speedX = Mathf.MoveTowards (speedX, defaultSpeed, defaultSpeed * Time.deltaTime / acceleration);
			transform.Translate (Vector2.right * speedX);
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
	}
}
