using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class GameManager : MonoBehaviour {

	public GameObject PausePanelControl;

	private ButtonDetect buttonDetectScript;

	private Text[] ButtonText = new Text[4];
	private Text QuestionText;

	float[] changePossesX =  new float[2] {150.0f, 233.0f};
	float[] changePossesY =  new float[2] {-152.0f, 158.0f};

	private static RectTransform[] ButtonPositions = new RectTransform[4];
	private static List<Question> unansweredQuetions;

	List<int> numbers = new List<int>(4);

	private AudioSource audioSource;

	[Header("Questions")]
	public Question[] questions;
	[HideInInspector]
	public Question currentQuestion;

	public GameObject[] ButtonObjects;

	[SerializeField]
	private AudioClip audioClip;

	[SerializeField]
	private Text NextQuestionTxt;

	void Start()
	{
		
		TimeControl (1.0f);
		FindComponents ();

		audioSource = GetComponent<AudioSource> ();
		audioSource.pitch = 1.94f;
		if (unansweredQuetions == null || unansweredQuetions.Count == 0) 
		{
			unansweredQuetions = questions.ToList<Question> ();
		}
		audioSource.PlayOneShot (audioClip);

		SetCurrentQuestion ();
	}

	IEnumerator TransitionToNextQuestion()
	{
		unansweredQuetions.Remove (currentQuestion);
		NextQuestionTxt.gameObject.SetActive(true);

		yield return new WaitForSeconds (0.5f);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	void Update()
	{
		// Deneme için ekledim.
		if (Input.GetKeyDown (KeyCode.A))
		{
			StartCoroutine (TransitionToNextQuestion ());
		}

		if (ButtonObjects [0].activeSelf == false &&
			ButtonObjects [1].activeSelf == false &&
			ButtonObjects [2].activeSelf == false &&
			ButtonObjects [3].activeSelf == false) 
		{
			StartCoroutine(TransitionToNextQuestion());
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

		int thisNumber;
		float posX;
		float posY;

		for (int i = 0; i <= 3; i++)
		{
			posX = UnityEngine.Random.Range (changePossesX[0], changePossesX[1]);
			posY = UnityEngine.Random.Range (changePossesY[0], changePossesY[1]);
			ButtonPositions [i].localPosition = new Vector2 (posX, posY);
			print ("X= " + posX + "Y= " + posY);
		}

	    int count = 0;
		while(count < 4)
		{
			ButtonObjects [count].SetActive (true);
			count++;
		}
		count = 0;

//		unansweredQuetions.RemoveAt (randomQuestionIndex);
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