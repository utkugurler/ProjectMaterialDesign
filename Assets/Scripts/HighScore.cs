using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public int currentScore;
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
		currentScore = PlayerPrefs.GetInt ("CurrentScore");
	}

	void ScoreControl()
	{
		if (maxScore < currentScore)
		{
			PlayerPrefs.SetInt ("MaxScore", currentScore);
			newScoreText.gameObject.SetActive (true);
		}
		currentScoreText.text = "Şu an ki skor: " + currentScore.ToString ();
		maxScoreText.text = "En yüksek skor: " + PlayerPrefs.GetInt ("MaxScore");
	}

	void LateUpdate()
	{
		PlayerPrefs.SetInt ("CurrentScore", currentScore);
		ScoreText.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString ();
		ScoreControl ();
		if(currentScore <= 0)
		{
			currentScore = 0;
		}
	}

}
