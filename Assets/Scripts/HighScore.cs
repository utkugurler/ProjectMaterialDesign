using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public int currentScore = 0;
	public int maxScore;

	[SerializeField]
	private Text ScoreText;

	[Header("Time Panel Scores")]
	[SerializeField]
	private Text currentScoreText;
	[SerializeField]
	private Text maxScoreText;
	[SerializeField]
	private Text newScoreText;

	void Awake()
	{
		maxScore = PlayerPrefs.GetInt ("MaxScore");
	}

	void ScoreControl()
	{
		if (maxScore < currentScore)
		{
			PlayerPrefs.SetInt ("MaxScore", currentScore);
			newScoreText.gameObject.SetActive (true);
		}
		currentScoreText.text = "Current Score: " + currentScore.ToString ();
		maxScoreText.text = "High Score: " + PlayerPrefs.GetInt ("MaxScore");
	}

	void LateUpdate()
	{
		//Debug.LogWarning ("Current Score: " + currentScore);
		ScoreText.text = "Score: " + currentScore.ToString ();
		ScoreControl ();
		if(currentScore <= 0)
		{
			currentScore = 0;
		}
	}

}
