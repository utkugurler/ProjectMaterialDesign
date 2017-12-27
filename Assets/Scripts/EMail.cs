using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class EMail : MonoBehaviour {
	
	[SerializeField]
	private Toggle[] toggleButtons;
	[SerializeField]
	private Text[] toggleText;
	public bool[] toggles;

	void Update()
	{
		for (int i = 0; i < 5; i++)
		{
			toggles [i] = toggleButtons [i].isOn;
		}
	}

	public void SendMail ()
	{ 
		string message = String.Format
			(toggleText[0].text + ": " + toggles[0] + "\n" + toggleText[1].text + ": " + toggles[1] + "\n" + 
				toggleText[2].text+ ": " + toggles[2] + "\n" + toggleText[3].text + ": " + toggles[3] + "\n" +
				toggleText[4].text+ ": " + toggles[4]);
		
		MailMessage mail = new MailMessage();
		mail.From = new MailAddress("mailadress");
		mail.To.Add("mailadress");
		mail.Subject = "Küçükten Büyüğe Oyunu Değerlendirme Formu";
		mail.Body = (message);  //"1.Soru: " + toggles[0] + "2.Soru: " + toggles[1] + "3.Soru: " + toggles[2];
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("mailadress", "password") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
		Debug.Log("Success");

	}

	public void MainMenu()
	{
		Application.LoadLevel ("main_menu");
	}
		
}
