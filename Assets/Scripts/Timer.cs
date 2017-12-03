using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public int timeLeft = 5;
	public Text countdownText;
	[SerializeField]
	private GameObject timePanel;

	void Start()
	{
		StartCoroutine("LoseTime");
	}

	void Update()
	{
		countdownText.text = ("Kalan Zaman: " + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
			Time.timeScale = 0.0f;
			timePanel.SetActive (true);
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}


}
