using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pot : MonoBehaviour {

	public GameObject player;

	public List<string> inventory;

	playerInventory playerInvScript;
	
	void Start () 
	{
		playerInvScript = player.GetComponent<playerInventory> ();
	}

	void Update () 
	{

	}
	void ShoveStuffInThePot()
	{
		
	}
	void OnTriggerEnter()
	{
		playerInvScript.playerNearPot = true;
	}
	void OnTriggerExit()
	{
		playerInvScript.playerNearPot = false;
	}
}
