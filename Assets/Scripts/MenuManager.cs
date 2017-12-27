using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	[SerializeField]
	private Text highscoreText;

	private void Start()
	{
		PlayerPrefs.SetInt("CurrentScore", 0);
		PlayerPrefs.SetInt ("TimeLeft", 30);
		highscoreText.text = ("HIGHSCORE: " + PlayerPrefs.GetInt ("MaxScore"));
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("level_1");
		print ("Start Game!");
	}

	public void QuitGame()
	{
		Application.Quit ();
		print ("Quit!");
	}

	public void TutorialGame()
	{
		SceneManager.LoadScene ("tutorial");
	}

	public void Evaluation()
	{
		SceneManager.LoadScene ("Evaluation");
	}
}
