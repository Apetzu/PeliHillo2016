using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clock : MonoBehaviour {

	public Text clockText;

	public float hours = 23f;
	public float minutes = 57f;
	public float seconds = 55f;

	bool updateFixer1;
	bool updateFixer2;

	void Start () 
	{

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
				Time.timeScale = 0;
				updateFixer2 = true;
			}
		}
		
		clockText.text = hours.ToString ("00") +":"+ minutes.ToString ("00") +":"+ seconds.ToString ("00");
	}
}
