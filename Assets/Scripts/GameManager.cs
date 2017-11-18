using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject PausePanelControl;
	float distance = 10;

	private void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = objPosition;
	}

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

}