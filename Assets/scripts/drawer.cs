using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class drawer : MonoBehaviour {

	public GameObject player;
	public GameObject textObj;

	public string pressEText; 
	public Text foundTextBox;

	playerInventory playerInvScript;


	public string objectInThisThingie;

	void Start () 
	{

	}
	void Update () 
	{

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		player = other.gameObject;
		playerInvScript = player.GetComponent<playerInventory> ();
		playerInvScript.playerNearDrawer = true;
		playerInvScript.objectInTheThingie = objectInThisThingie;
		pressEText = "Press E to search drawer.";
		textObj.GetComponent<textBox>().TextUpdate(pressEText);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		playerInvScript.playerNearDrawer = false;
		pressEText = " ";
		textObj.GetComponent<textBox>().TextUpdate(pressEText, false);
	}
}
