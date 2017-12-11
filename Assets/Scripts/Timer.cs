using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public int timeLeft = 30;
	public Text countdownText;

	[SerializeField]
	private GameObject timePanel;
	[SerializeField]
	private AudioClip audioClip;
	private AudioSource audioSource;

	void Start()
	{
		timeLeft = PlayerPrefs.GetInt ("TimeLeft");

		if (timeLeft <= 0) 
		{
			timeLeft = 30;
		}

		audioSource = GetComponent<AudioSource> ();
		StartCoroutine(LoseTime());
	}

	void Update()
	{
		PlayerPrefs.SetInt ("TimeLeft", timeLeft);
		countdownText.text = ("Kalan Zaman: " + PlayerPrefs.GetInt ("TimeLeft"));
		if (timeLeft <= 0) 
		{
			StopCoroutine (LoseTime());
			countdownText.text = "Times Up!";
			timePanel.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;

		//		audioSource.PlayOneShot (audioClip);
		}
	}


}
