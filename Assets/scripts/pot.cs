using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pot : MonoBehaviour {

	public GameObject player;
	public GameObject textObj;
	
	public string pressEText; 
	public string foundTextBox;

	public Text tutorial;

	public List<string> inventory;

	playerInventory playerInvScript;
	
	void Start () 
	{
		playerInvScript = player.GetComponent<playerInventory> ();
	}

	void Update () 
	{
		if (inventory.Count >= 3)
		{
			tutorial.text = ("Return to area you started at");
		}
	}
	public void ShoveStuffInThePot()
	{
		foundTextBox = ("You found: "+'\n'+inventory[0]+", "+inventory[1]+" and "+inventory[2]);
		textObj.GetComponent<textBox>().TextUpdate(foundTextBox);
		StartCoroutine (delay ());
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		playerInvScript.playerNearPot = true;
		pressEText = "Press E to return objects.";
		textObj.GetComponent<textBox>().TextUpdate(pressEText);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		playerInvScript.playerNearPot = false;
	}
	IEnumerator delay()
	{
		yield return new WaitForSeconds(3f);
		Application.LoadLevel ("endCutscene");
	}
}
