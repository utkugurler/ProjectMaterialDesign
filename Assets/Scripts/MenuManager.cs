using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

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
}
