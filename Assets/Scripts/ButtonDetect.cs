using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ButtonDetect : MonoBehaviour {
	public string questionLocal;
	public HighScore highScore;

	private GameManager GM;
	private string[] ucgen = new [] { "ucgen_0", "ucgen_1", "ucgen_2", "ucgen_3" };
	private string[] button = new[] {"Button0", "Button1", "Button2", "Button3"};
	private int localScore;

	void Start()
	{
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void CorrectQuest()
	{
		localScore++;
		gameObject.SetActive (false);
	}

	void WrongQuest()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == ucgen[0] && gameObject.name == button[0])
		{
			CorrectQuest ();
		}
		if (other.gameObject.name == ucgen [1] && gameObject.name== button [1]) 
		{
			CorrectQuest ();
		}
		if (other.gameObject.name == ucgen [2] && gameObject.name == button [2]) 
		{
			CorrectQuest ();
		}
		if (other.gameObject.name == ucgen [3] && gameObject.name == button [3]) 
		{
			CorrectQuest ();
		}
	}
}