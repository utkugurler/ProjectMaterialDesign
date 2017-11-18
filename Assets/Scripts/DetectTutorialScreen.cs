using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectTutorialScreen : MonoBehaviour {

	void Start()
	{
		if (PlayerPrefs.GetInt ("TutorialEnd") == 1) {
			print (PlayerPrefs.GetInt ("TutorialEnd"));
			SceneManager.LoadScene ("main_menu");
		} else {
			print (PlayerPrefs.GetInt ("TutorialEnd"));
			SceneManager.LoadScene ("tutorial");
		}
	}

}
