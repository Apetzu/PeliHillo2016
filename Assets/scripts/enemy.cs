using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject combatHandler;
	public GameObject combatFadeout;
	public GameObject player;

	public float health = 10f;

	combat combatScript;
	player playerMoveScript;

	void Start () 
	{
		combatScript = combatHandler.GetComponent<combat> ();
		playerMoveScript = player.GetComponent<player> ();
	}

	void Update () 
	{
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "player")
		{
			StartCoroutine (startCombat());
		}
	}
	IEnumerator startCombat()
	{
		combatFadeout.GetComponent<Animator> ().SetTrigger("fadeout");
		playerMoveScript.enabled = false;
		yield return new WaitForSeconds (1.5f);
		combatScript.ChangeCamera();
		combatScript.StartCombat();
		combatScript.currentEnemy = this.gameObject;
	}
}
