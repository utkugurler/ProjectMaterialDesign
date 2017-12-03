using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDetect : MonoBehaviour {
	public string questionLocal;

	private string[] ucgen = new [] { "ucgen_0", "ucgen_1", "ucgen_2", "ucgen_3" };
	private string[] button = new[] {"Button0", "Button1", "Button2", "Button3"};

	public int localScore = 0;
	HighScore highScoreScript;

	void Start()
	{
		GameObject HScore = GameObject.Find ("GameManager");
		highScoreScript = HScore.GetComponent<HighScore> ();
	}

	void Update()
	{
		//CorrectQuest ();
	}

	void CorrectQuest()
	{
		highScoreScript.currentScore++;
		this.gameObject.SetActive (false);
	}

	void WrongQuest()
	{
		highScoreScript.currentScore--;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == ucgen[0] && gameObject.name == button[0])
			CorrectQuest ();

		if (other.gameObject.name == ucgen [1] && gameObject.name== button [1]) 
			CorrectQuest ();

		if (other.gameObject.name == ucgen [2] && gameObject.name == button [2]) 
			CorrectQuest ();
		
		if (other.gameObject.name == ucgen [3] && gameObject.name == button [3])
			CorrectQuest ();
		if
		   (other.gameObject.name != ucgen[0] && gameObject.name != button[0]   && 
			other.gameObject.name != ucgen [1] && gameObject.name != button [1] &&
			other.gameObject.name != ucgen [2] && gameObject.name != button [2] &&
			other.gameObject.name != ucgen [3] && gameObject.name != button [3] )
			WrongQuest ();
	}
}