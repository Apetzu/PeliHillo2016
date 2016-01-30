using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour {

	public bool playerNearDrawer;
	public bool playerNearPot;

	public string objectInTheThingie;

	public Text foundTextBox;

	public GameObject pot;
	public GameObject drawer;

	pot potScript;
	drawer drawerScript;

	int currentlyDisplayingText;

	public GameObject textObj;



	public string foundText;
	
	void Start () 
	{
		potScript = pot.GetComponent<pot> ();
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (playerNearDrawer == true)
			{
				foundTextBox.gameObject.SetActive(true);
				foundText = "you found " + objectInTheThingie;
				textObj.GetComponent<textBox>().TextUpdate(foundText);
				StartCoroutine(ResetText());
				potScript.inventory.Add (objectInTheThingie);
				drawerScript = drawer.GetComponent<drawer> ();
				drawerScript.KillCollider();
				drawerScript.GetComponent<CircleCollider2D>().enabled = false;
			}
			if (playerNearPot == true)
			{
				potScript.ShoveStuffInThePot();
			}
		}
	}
	IEnumerator ResetText()
	{
		yield return new WaitForSeconds (3f);
		textObj.GetComponent<textBox> ().TextUpdate ("", false);

	}
}
