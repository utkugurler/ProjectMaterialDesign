using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class GameManager : MonoBehaviour {

	public GameObject PausePanelControl;

	[Header("Questions")]
	public Question[] questions;

	[HideInInspector]
	public Question currentQuestion;

	private static RectTransform[] ButtonPositions = new RectTransform[4];
	private static List<Question> unansweredQuetions;

	private Text[] ButtonText = new Text[4];
	private Text QuestionText;

	float[] changePossesX = new float[2] {7.9f, 194.7f};
	float[] changePossesY = new float[2] {84.7f, 42.6f};

	private System.Random random = new System.Random ();

	public GameObject[] ButtonObjects;

	List<int> numbers = new List<int>(4);

	private AudioSource audioSource;

	[SerializeField]
	private AudioClip audioClip;

	void Start()
	{
		TimeControl (1.0f);
		FindComponents ();
		audioSource = GameObject.Find("GameManager").GetComponent<AudioSource> ();
		if (unansweredQuetions == null || unansweredQuetions.Count == 0) 
		{
			unansweredQuetions = questions.ToList<Question> ();
		}

		SetCurrentQuestion ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			SetCurrentQuestion ();
		}
		int i = 0;

		if (ButtonObjects [0].activeSelf == false &&
			ButtonObjects [1].activeSelf == false &&
			ButtonObjects [2].activeSelf == false &&
			ButtonObjects [3].activeSelf == false) 
		{
			SetCurrentQuestion ();
		}
	}

	public void SetCurrentQuestion()
	{
		int randomQuestionIndex = UnityEngine.Random.Range (0, unansweredQuetions.Count);
		currentQuestion = unansweredQuetions [randomQuestionIndex];
		QuestionText.text = currentQuestion.question;

		for (int i = 0; i < 4; i++) 
		{
			ButtonText[i].text = currentQuestion.answers [i];
		}

		for (int i = 0; i <= 1; i++) 
		{
			numbers.Add(i);
		}

		int thisNumber;
		float posX;
		float posY;

		for (int i = 0; i <= 3; i++)
		{
			//thisNumber = UnityEngine.Random.Range (0, 1);
			posX = UnityEngine.Random.Range (40f, 220f);
			posY = UnityEngine.Random.Range (201f, -400f);
//			Debug.Log ("Random" + i + "number:" + thisNumber);
			ButtonPositions [i].localPosition = new Vector2 (posX, posY);
//			numbers.Remove(thisNumber);
		}
	    int count = 0;
		while(count < 4)
		{
			ButtonObjects [count].SetActive (true);
			count++;
		}
		count = 0;
		unansweredQuetions.RemoveAt (randomQuestionIndex);
		audioSource.PlayOneShot (audioClip);
	}

	void FindComponents()
	{
		for(int i= 0; i <= 3; i++)
		{
			ButtonPositions[i] = GameObject.Find ("Canvas/Buttons/Button" + i).GetComponent<RectTransform>();
			Debug.Log ("Button" + i + " position :" + ButtonPositions[i].transform.position.y);
			ButtonText[i] = GameObject.Find ("Canvas/Buttons/Button" + i + "/Text").GetComponent<Text>();
		}
		QuestionText = GameObject.Find ("Canvas/Question").GetComponent<Text> ();
	}

#region Menus
	public void MainMenu()
	{
		SceneManager.LoadScene ("main_menu");
		print ("Main Menu!");
	}
	
	public void PausePanel()
	{
		PausePanelControl.SetActive (true);
		TimeControl (0.0f);
		print (Time.timeScale);
	}

	public void ResumeButton()
	{
		PausePanelControl.SetActive (false);
		TimeControl (1.0f);
	}

	private void TimeControl(float newTime)
	{
		Time.timeScale = newTime;
	}
#endregion
}