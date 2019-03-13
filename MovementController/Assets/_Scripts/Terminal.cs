using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
	public TerminalController server;
	public int hackingLives;
	protected string twist="twist", aware="aware", mayor="mayor", swarm="swarm", smell="smell", video="video", blast="blast", shave="shave", youth="youth", peace="peace", 
					 shift="shift", donor="donor", awful="awful", tough="tough", hobby="hobby", wheel="wheel", style="style", tight="tight", drown="drown", abuse="abuse", 
					 stick="stick", sweet="sweet", elect="elect", brave="brave", split="split", crime="crime", clerk="clerk", penny="penny", tribe="tribe", pound="pound";
	protected int WordToAdd;
	protected int SimilarityRating;
	protected bool isWordSame;
	protected bool isHacked;
	protected bool hasFailedHack;
	protected string targetWord;
	protected string selectedWord;
	protected List<Text> TextArray;
	protected List<string> WordArray;
	protected char[] tWordArray;
	protected char[] sWordArray;

	void Start()
	{
		isHacked = false;
		hasFailedHack = false;
	}
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player"){
			server.interactUI.SetActive(true);
		}
	}
	void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.tag == "Player" && Input.GetButton("Interact") && server.terminalInterface.activeSelf == false)
		{
			server.usernameField.text = "";
			server.passwordField.text = "";

			if(server.terminalInterface != null)
			{
				server.terminalInterface.SetActive(true);
			}

			if(server.interactUI != null)
			{
				server.interactUI.SetActive(false);
			}
			server.camScript.enabled = false;
			server.movScript.enabled = false;
			Rigidbody _rb = server.player.GetComponent<Rigidbody>();
			_rb.velocity = new Vector3(0,0,0);
			Cursor.lockState = CursorLockMode.None;

			if (server.doesRequireLogin == true || hasFailedHack == true)
			{
				server.bypassButton.interactable = false;
			}
			else if (server.doesRequireLogin == false && isHacked == false)
			{
				
				TextArray = new List<Text> {server.A1, server.A2, server.A3, server.A4, server.A5, server.A6, server.A7, server.A8, server.A9, server.A10,
											server.B1, server.B2, server.B3, server.B4, server.B5, server.B6, server.B7, server.B8, server.B9, server.B10,
											server.C1, server.C2, server.C3, server.C4, server.C5, server.C6, server.C7, server.C8, server.C9, server.C10};
				WordArray = new List<string> {twist, aware, mayor, swarm, smell, video, blast, shave, youth, peace,
									     	  shift, donor, awful, tough, hobby, wheel, style, tight, drown, abuse, 
											  stick, sweet, elect, brave, split, crime, clerk, penny, tribe, pound};

				for (int i = 0; i < TextArray.Count; i++) 
				{ 
					TextArray[i].text = ""; 
				}
				
				for (int i = 0; i < TextArray.Count; i++)
				{
					isWordSame = false;
					while (isWordSame == false)
					{
						WordToAdd = Random.Range(0, WordArray.Count);
						isWordSame = CheckWord(WordToAdd);
					}
					TextArray[i].text = WordArray[WordToAdd];
				}
				targetWord = WordArray[Random.Range(0, WordArray.Count)];
				Debug.Log("Target word is " + targetWord + "!!");
			}
		}

		if (selectedWord != server.txtScript.Word && isHacked == false)
		{
			selectedWord = server.txtScript.Word;

			SimilarityRating = 0;

			tWordArray = targetWord.ToCharArray();
			sWordArray = selectedWord.ToCharArray();

			if (sWordArray.Length > 0)
			{
				for (int i = 0; i < tWordArray.Length; i++)
				{
					if (tWordArray[i] == sWordArray[i])
					{
						SimilarityRating++;
					}
				}
				if (SimilarityRating == 0)
				{
					hackingLives--;
					if (hackingLives < 0)
					{
						hasFailedHack = true;
						server.bypassScreen.SetActive(false);
						server.loginScreen.SetActive(true);
						server.bypassButton.interactable = false;
					}
				}
			}
		}

		server.SimilarityRatingText.text = ("Similarity: " + SimilarityRating);
		Debug.Log("Similiarity Rating " + SimilarityRating);
		server.HackingLivesText.text = ("Lives: " + hackingLives);

		if (SimilarityRating == 5 && isHacked == false)
		{
			server.usernameField.text = "";
			server.passwordField.text = "";

			server.terminalMenu.SetActive(true);
			server.bypassScreen.SetActive(false);

			isHacked = true;
			SimilarityRating = 0;
		}
		if (isHacked == true && server.bypassScreen.activeSelf == true)
		{
			server.terminalMenu.SetActive(true);
			server.bypassScreen.SetActive(false);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			server.terminalInterface.SetActive(false);
			server.camScript.enabled = true;
			server.movScript.enabled = true;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.lockState = CursorLockMode.Locked;
		}
		server.interactUI.SetActive(false);
	}	
	bool CheckWord(int index)
	{
		for (int i = 0; i < TextArray.Count; i++)
		{
			if (WordArray[index] == TextArray[i].text)
			{
				Debug.Log("Word is invalid!");
				return false;
			}
		}
		Debug.Log("Word is valid!");
		return true;
	}
}
