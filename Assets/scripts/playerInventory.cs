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
			}
			if (playerNearPot == true)
			{
				//build the masterbossthingfuckery
			}
		}
	}
	IEnumerator ResetText()
	{
		yield return new WaitForSeconds (3f);
		textObj.GetComponent<textBox> ().TextUpdate ("", false);

	}
	/*IEnumerator AnimateText()
	{
		for (int i = 0; i < (foundText[currentlyDisplayingText].Length+1); i++)
		{
			foundTextBox.text = foundText[currentlyDisplayingText].Substring (0, i);
			yield return new WaitForSeconds (0.03f);
		}
	}*/
}
