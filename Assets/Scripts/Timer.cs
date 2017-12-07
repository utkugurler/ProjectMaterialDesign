using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public int timeLeft = 30;
	public Text countdownText;
	[SerializeField]
	private GameObject timePanel;

	private AudioSource audioSource;

	[SerializeField]
	private AudioClip audioClip;

	void Start()
	{
		timeLeft = PlayerPrefs.GetInt ("TimeLeft");

		if (timeLeft <= 0) 
		{
			timeLeft = 30;
		}
			
		StartCoroutine("LoseTime");
		audioSource = GetComponent<AudioSource> ();
	}

	void Update()
	{
		PlayerPrefs.SetInt ("TimeLeft", timeLeft);
		countdownText.text = ("Kalan Zaman: " + PlayerPrefs.GetInt ("TimeLeft"));
		if (timeLeft <= 0)
		{
			
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
			Time.timeScale = 0.0f;
			timePanel.SetActive (true);
		}
		if (timePanel.activeSelf == true) 
		{
			audioSource.PlayOneShot (audioClip);
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;

		//	audioSource.PlayOneShot (audioClip);
		}
	}


}
