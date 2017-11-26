using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

	public GameObject PausePanelControl;
	[Header("Questions")]
	public Question[] questions;

	[HideInInspector]
	public Question currentQuestion;
	[HideInInspector]
	public string deneme;

	private static RectTransform[] ButtonPositions = new RectTransform[4];
	private static List<Question> unansweredQuetions;

	private Text[] ButtonText = new Text[4];
	private Text QuestionText;

	void Start()
	{
		FindComponents ();

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
	}
	void SetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuetions.Count);
		currentQuestion = unansweredQuetions [randomQuestionIndex];
		QuestionText.text = currentQuestion.question;

		for (int i = 0; i < 4; i++) 
		{
			ButtonText[i].text = currentQuestion.answers [i];
		}

		unansweredQuetions.RemoveAt (randomQuestionIndex);
	}

	void FindComponents()
	{
		for(int i= 0; i <= 3; i++)
		{
			ButtonPositions[i] = GameObject.Find ("Canvas/Buttons/Button" + i).GetComponent<RectTransform>();
			Debug.Log ("Button" + i + " position :" + ButtonPositions[i].transform.position);
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