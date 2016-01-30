using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textBox : MonoBehaviour {

	Text textObj;
	public string[] textNow = new string[] { " "};
	public float textSpeed = 0.03f;

	void Start()
	{
		textObj = GetComponent<Text> ();
	}

	public void TextUpdate(string text, bool animOn = true, string hexColor = "ffffff")
	{
		Color color = HexToColor (hexColor);
		if (animOn == true)
		{
			textObj.color = color;
			StartCoroutine (AnimateText(text));
		}
		else
		{
			textObj.color = color;
			textObj.text = text;
		}
	}

	// http://wiki.unity3d.com/index.php?title=HexConverter by mvi
	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}

	IEnumerator AnimateText(string animText)
	{
		for (int i = 0; i < animText.Length + 1; i++)
		{
			textObj.text = animText.Substring (0, i);
			yield return new WaitForSeconds (textSpeed);
		}
	}
}
