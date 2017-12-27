using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDetect : MonoBehaviour {
	public string questionLocal;

	private string[] ucgen = new [] { "ucgen_0", "ucgen_1", "ucgen_2", "ucgen_3" };
	private string[] button = new[] {"Button0", "Button1", "Button2", "Button3"};
	//private GameObject[] buttonObject = new GameObject[4]; 

	public int localScore;
	HighScore highScoreScript;

	private AudioSource audioSource;
	[SerializeField]
	private AudioClip[] audioClips;

	public Text[] triangleText;
	[SerializeField]
	private Text[] buttonText;
	[SerializeField]
	private Text[] textStatus;

	private Timer timerScript;


	void Start()
	{
		GameObject HScore = GameObject.Find ("GameManager");
		highScoreScript = HScore.GetComponent<HighScore> ();
		audioSource = GameObject.Find("GameManager").GetComponent<AudioSource> ();
		GameObject Timerscript = GameObject.Find ("GameManager");
		timerScript = Timerscript.GetComponent<Timer> ();
	}

	void CorrectQuest()
	{
		++highScoreScript.currentScore;

		this.gameObject.SetActive (false);
		audioSource.PlayOneShot (audioClips [0]);
		timerScript.timeLeft += 2;
		textStatus [0].gameObject.SetActive (true);
		textStatus [1].gameObject.SetActive (false);
	}

	void WrongQuest()
	{
		highScoreScript.currentScore--;
		audioSource.PlayOneShot (audioClips [1]);
		timerScript.timeLeft -= 1;
		textStatus [0].gameObject.SetActive (false);
		textStatus [1].gameObject.SetActive (true);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == ucgen [0] && gameObject.name == button [0]) {
			CorrectQuest ();
			triangleText[0].gameObject.SetActive(true);
			triangleText[0].text = buttonText[0].text;
		} else if (other.gameObject.name == ucgen [1] && gameObject.name == button [1]) {
			CorrectQuest ();
			triangleText[1].gameObject.SetActive(true);
			triangleText[1].text = buttonText[1].text;
		} else if (other.gameObject.name == ucgen [2] && gameObject.name == button [2]) { 
			CorrectQuest ();
			triangleText[2].gameObject.SetActive(true);
			triangleText[2].text = buttonText[2].text;
		} else if (other.gameObject.name == ucgen [3] && gameObject.name == button [3]) {
			CorrectQuest ();
			triangleText[3].gameObject.SetActive(true);
			triangleText[3].text = buttonText[3].text;
		}
		else 
		{
			WrongQuest ();
		}
	}
}