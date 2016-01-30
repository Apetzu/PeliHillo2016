using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class drawer : MonoBehaviour {

	public GameObject player;

	public Text pressEText; 
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
		pressEText.text = "Press 'e' to search drawer.";
	}
	void OnTriggerExit2D(Collider2D other)
	{
		playerInvScript.playerNearDrawer = false;
		pressEText.text = " ";
	}
}
