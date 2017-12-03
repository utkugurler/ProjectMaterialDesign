using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDetect : MonoBehaviour {
	public string questionLocal;

	private string[] ucgen = new [] { "ucgen_0", "ucgen_1", "ucgen_2", "ucgen_3" };
	private string[] button = new[] {"Button0", "Button1", "Button2", "Button3"};
	private GameObject[] buttonObject = new GameObject[4]; 

	public int localScore = 0;
	HighScore highScoreScript;

	private AudioSource audioSource;
	[SerializeField]
	private AudioClip[] audioClips;

	void Start()
	{
		GameObject HScore = GameObject.Find ("GameManager");
		highScoreScript = HScore.GetComponent<HighScore> ();

		audioSource = GameObject.Find("GameManager").GetComponent<AudioSource> ();
	}

	void CorrectQuest()
	{
		++highScoreScript.currentScore;
		this.gameObject.SetActive (false);
		audioSource.PlayOneShot (audioClips [0]);
	}

	void WrongQuest()
	{
		highScoreScript.currentScore--;
		audioSource.PlayOneShot (audioClips [1]);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == ucgen[0] && gameObject.name == button[0])
			CorrectQuest ();

		else if (other.gameObject.name == ucgen [1] && gameObject.name== button [1]) 
			CorrectQuest ();

		else if (other.gameObject.name == ucgen [2] && gameObject.name == button [2]) 
			CorrectQuest ();
		
		else if (other.gameObject.name == ucgen [3] && gameObject.name == button [3])
			CorrectQuest ();
		else 
		{
			WrongQuest ();
		}
	}
}