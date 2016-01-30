using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pot : MonoBehaviour {

	public GameObject player;
	public GameObject textObj;

	public string foundTextBox;

	public List<string> inventory;

	playerInventory playerInvScript;
	
	void Start () 
	{
		playerInvScript = player.GetComponent<playerInventory> ();
	}

	void Update () 
	{

	}
	public void ShoveStuffInThePot()
	{
		foundTextBox = ("you found: "+'\n'+inventory[0]+", "+inventory[1]+","+'\n'+inventory[2]+" and "+inventory[3]);
		textObj.GetComponent<textBox>().TextUpdate(foundTextBox);	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		playerInvScript.playerNearPot = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		playerInvScript.playerNearPot = false;
	}
}
