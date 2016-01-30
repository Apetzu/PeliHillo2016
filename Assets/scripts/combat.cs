using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combat : MonoBehaviour {

	public Camera MainCamera;
	public Camera combatCamera;
	public GameObject combatPlayer;
	public GameObject combatEnemy;
	public GameObject player;
	public GameObject enemy;
	public GameObject playerCombatButtons;
	public GameObject currentEnemy;
	public GameObject turnIndicatorDoge;
	public GameObject turnIndicatorPlayer;
	public GameObject combatFadeoutCombat;
	public Text combatFeedback;
	public Text enemyHealth;
	public Text playerHealth;
	
	float startXPosEnemy;
	float startXPosPlayer;
	public float shakeTimer = 1.5f;
	public float speed = 30f;

	bool shakePlayer;
	bool shakeEnemy;
	public bool playerTurnBool;

	player playerMoveScript;
	enemy enemyScript;
	int currentlyDisplayingText;

	public string[] combatText = new string[] { " "};

	void Start () 
	{
		startXPosEnemy = combatEnemy.transform.position.x;
		startXPosPlayer = combatPlayer.transform.position.x;
		enemyScript = enemy.GetComponent<enemy> ();
		MainCamera.enabled = true;
		combatCamera.enabled = false;
		playerMoveScript = player.GetComponent<player> ();
	}

	void Update () 
	{
		if (shakeEnemy == true)
		{
			combatEnemy.transform.position = new Vector2 (startXPosEnemy + Mathf.Sin((Time.time * 0.5f)* speed),combatEnemy.transform.position.y);
			shakeTimer -= Time.deltaTime;
			if (shakeTimer < 0)
			{
				shakeEnemy = false;
				combatEnemy.transform.position = new Vector2 (startXPosEnemy,combatEnemy.transform.position.y);
				shakeTimer = 1.5f;
			}
		}
		if (shakePlayer == true)
		{
			combatPlayer.transform.position = new Vector2 (startXPosPlayer + Mathf.Sin((Time.time * 0.5f)* speed),combatPlayer.transform.position.y);
			shakeTimer -= Time.deltaTime;
			if (shakeTimer < 0)
			{
				shakePlayer = false;
				combatPlayer.transform.position = new Vector2 (startXPosPlayer,combatPlayer.transform.position.y);
				shakeTimer = 1.5f;
			}
		}
	}
	public void StartCombat()
	{
		combatFadeoutCombat.GetComponent<Animator> ().SetTrigger("fadeout");
		StartCoroutine (fadeoutFixer ());
		turnIndicatorDoge.SetActive (false);
		turnIndicatorPlayer.SetActive (false);
		playerTurnBool = false;
		StartCoroutine (EnemyTurn());
		enemyScript.health = 10f;
		enemyHealth.text = ("health: "+enemyScript.health);
		combatText = new string[] {"Encountered a wild doge"};
		StartCoroutine (AnimateText ());
		//combatFadeoutCombat.GetComponent<Animator> ().speed = -0.2f;
	}
	IEnumerator fadeoutFixer()
	{
		yield return new WaitForSeconds (1.3f);
		combatFadeoutCombat.GetComponent<Animator> ().SetTrigger("fadeout");
		combatFadeoutCombat.SetActive (false);
		//combatFadeoutCombat.GetComponent<Animator> ().speed = 0.2f;
	}
	public void ChangeCamera()
	{
		MainCamera.enabled = !MainCamera.enabled;
		combatCamera.enabled = !combatCamera.enabled;
	}
	void playerTurn()
	{
		turnIndicatorPlayer.SetActive (true);
		turnIndicatorDoge.SetActive (false);
		if (playerMoveScript.health <= 0)
		{
			StartCoroutine(playerLost());
			StartCoroutine (AnimateText ());
		}
		playerCombatButtons.SetActive (true);
		playerTurnBool = true;
	}
	public void AttackStab()
	{
		if (playerTurnBool == true)
		{
			combatText = new string[] {"You: Bring out the knifey - 100 000 Damage"};
			StartCoroutine(AnimateText());
			enemyScript.health -= 100000f;
			shakeEnemy = true;
			enemyHealth.text = ("health: "+enemyScript.health);
			playerTurnBool = false;
			if (enemyScript.health > 0)
			{
				StartCoroutine(EnemyTurn());
			}
			else
			{
				StartCoroutine(playerWon ());
			}
		}
	}
	public void AttackRock()
	{
		if (playerTurnBool == true)
		{
			combatText = new string[] {"You: Taste my rocks! - 3 Damage"};
			StartCoroutine(AnimateText());
			enemyScript.health -= 3f;
			shakeEnemy = true;
			enemyHealth.text = ("health: "+enemyScript.health);
			playerTurnBool = false;
			if (enemyScript.health <= 0)
			{
				StartCoroutine(playerWon ());
			}
			else
			{
				StartCoroutine(EnemyTurn());
			}
		}
	}
	IEnumerator playerLost()
	{
		combatText = new string[] {"You died and lost the game"};
		yield return new WaitForSeconds (3);
		Application.LoadLevel (Application.loadedLevel);
	}
	IEnumerator playerWon()
	{
		yield return new WaitForSeconds (2.5f);
		combatText = new string[] {"Doge fainted"};
		StartCoroutine (AnimateText ());
		yield return new WaitForSeconds (1);
		Destroy (currentEnemy);
		playerMoveScript.enabled = true;
		ChangeCamera ();
		combatFadeoutCombat.SetActive (true);
	}
	IEnumerator EnemyTurn ()
	{
		yield return new WaitForSeconds (2.5f);
		turnIndicatorPlayer.SetActive (false);
		turnIndicatorDoge.SetActive (true);
		combatText = new string[] {"Doge: Bark! bark! woof! woof! - 0 damage"};
		playerMoveScript.health -= 0f;
		shakePlayer = true;
		playerHealth.text = ("health: "+playerMoveScript.health);
		StartCoroutine(AnimateText());
		yield return new WaitForSeconds (1.5f);
		playerTurn ();
	}
	IEnumerator AnimateText()
	{
		for (int i = 0; i < (combatText[currentlyDisplayingText].Length+1); i++)
		{
			combatFeedback.text = combatText[currentlyDisplayingText].Substring (0, i);
			yield return new WaitForSeconds (0.03f);
		}
	}
}
