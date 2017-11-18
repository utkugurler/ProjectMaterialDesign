using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public Animator[] buttons;
	public Text nextButtonText;

	public void PlayAnimation()
	{
		if (nextButtonText.text == "İleri") {
			for (int i = 0; i < 4; i++) {
				buttons [i].GetComponent<Animator> ();
				buttons [i].Play ("Button" + i);
				print (i);
			}
			nextButtonText.text = "Anladım";
		}
		else if (nextButtonText.text == "Anladım") {
			PlayerPrefs.SetInt ("TutorialEnd", 1);
			SceneManager.LoadScene ("main_menu");
		}
	}
}
