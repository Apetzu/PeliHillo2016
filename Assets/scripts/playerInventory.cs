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

	pot potScript;

	int currentlyDisplayingText;



	public string[] foundText = new string[] { " "};
	
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
				foundText = new string[] {"you found " + objectInTheThingie};
				StartCoroutine(AnimateText());
				StartCoroutine(ResetShit());
				potScript.inventory.Add (objectInTheThingie);
			}
			if (playerNearPot == true)
			{
				//build the masterbossthingfuckery
			}
		}
	}
	IEnumerator ResetShit()
	{
		yield return new WaitForSeconds (2f);
		foundTextBox.gameObject.SetActive(false);
	}
	IEnumerator AnimateText()
	{
		for (int i = 0; i < (foundText[currentlyDisplayingText].Length+1); i++)
		{
			foundTextBox.text = foundText[currentlyDisplayingText].Substring (0, i);
			yield return new WaitForSeconds (0.03f);
		}
	}
}
