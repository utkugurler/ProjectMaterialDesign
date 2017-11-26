using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public int currentScore;
	public Text ScoreText;

	void Start () {
		currentScore = 0;
	}

	void Update()
	{
		ScoreText.text = "Score: " + currentScore.ToString ();
	}

}
