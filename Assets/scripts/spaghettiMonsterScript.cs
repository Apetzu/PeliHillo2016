using UnityEngine;
using System.Collections;

public class spaghettiMonsterScript : MonoBehaviour {

	public GameObject spaghettiMonster;
	public GameObject Canvas;

	public void SummonTheSpaghettiMonster()
	{
		spaghettiMonster.SetActive (true);
	}

	public void CanvasSpawner()
	{
		Canvas.SetActive (true);
	}
}
