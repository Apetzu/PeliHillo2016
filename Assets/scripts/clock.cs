using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class clock : MonoBehaviour {

	public Text clockText;
	public Text foundTextBox;

	public GameObject textObj;
	public GameObject Garry;
	public GameObject player;

	public float hours = 23f;
	public float minutes = 57f;
	public float seconds = 55f;


	player playerScript;

	bool updateFixer1;
	bool updateFixer2;

	public string foundText;

	void Start () 
	{
		playerScript = player.GetComponent<player> ();
	}

	void FixedUpdate ()
	{
		seconds += Time.fixedDeltaTime;
		if (seconds > 59)
		{	
			if (updateFixer1 == false)
			{
				seconds = 0;
				minutes++;
				updateFixer1 = true;
			}
		}
		else
		{
			updateFixer1 = false;
		}
		if (minutes > 59)
		{
			if (updateFixer2 == false)
			{
				seconds = 0;
				minutes = 0;
				hours = 0;
				//Time.timeScale = 0;
				StartCoroutine (playerLost());
				updateFixer2 = true;
			}
		}
		
		clockText.text = hours.ToString ("00") +":"+ minutes.ToString ("00") +":"+ seconds.ToString ("00");
	}
	IEnumerator playerLost()
	{
		playerScript.enabled = false;
		yield return new WaitForSeconds(0.5f);
		foundText = "Lucifer: We... we didn't make it...";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"FF0000FF");
		yield return new WaitForSeconds(3.5f);
		foundText = "Lucifer: I can't believe we didn't make it in time...";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"FF0000FF");
		yield return new WaitForSeconds(3.5f);
		foundText = "Lucifer: We have failed our master.";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"FF0000FF");
		yield return new WaitForSeconds(3.5f);
		foundText = "Lucifer: No... GARRY, failed our master.";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"FF0000FF");
		yield return new WaitForSeconds(3.5f);
		foundText = "Bob: Goddamnit Garry!";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"0095FFFF");
		yield return new WaitForSeconds(3.5f);
		foundText = "Garry: I'm sorry guys... I didn't mea...";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"A7FF00FF");
		yield return new WaitForSeconds(1.3f);
		foundText = "Lucifer: SILENCE!!";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"FF0000FF");
		yield return new WaitForSeconds(3f);
		foundText = "Lucifer: Your failure will not be forgotten.";
		textObj.GetComponent<textBox>().TextUpdate(foundText,true,"FF0000FF");
		yield return new WaitForSeconds(3.5f);
		Destroy (Garry.gameObject);
	}
}
