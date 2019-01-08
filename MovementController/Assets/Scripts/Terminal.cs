using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{

	public GameObject terminalInterface;
	public CameraScript camScript;
	public MovementScript movScript;
	public GameObject player;
	public GameObject cam;
	public Text A1, A2, A3, A4, A5, A6, A7, A8, A9, A10,
				B1, B2, B3, B4, B5, B6, B7, B8, B9, B10,
				C1, C2, C3, C4, C5, C6, C7, C8, C9, C10;

	protected string twist="twist", aware="aware", mayor="mayor", swarm="swarm", smell="smell", video="video", blast="blast", shave="shave", youth="youth", peace="peace", 
					 shift="shift", donor="donor", awful="awful", tough="tough", hobby="hobby", wheel="wheel", style="style", tight="tight", drown="drown", abuse="abuse", 
					 stick="stick", sweet="sweet", elect="elect", brave="brave", split="split", crime="crime", clerk="clerk", penny="penny", tribe="tribe", pound="pound";
	protected int WordToAdd;
	protected bool isWordSame;
	protected string targetWord;
	protected string selectedWord;
	protected List<Text> TextArray;
	protected List<string> WordArray; 

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		movScript = player.GetComponent<MovementScript>();

		cam = GameObject.FindGameObjectWithTag("MainCamera");
		camScript = cam.GetComponent<CameraScript>();
	}
	void OnTriggerEnter(Collider other) 
	{
		
	}
	void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return) && terminalInterface.activeSelf == false)
		{
			terminalInterface.SetActive(true);
			camScript.enabled = false;
			movScript.enabled = false;
			Cursor.lockState = CursorLockMode.None;

			TextArray = new List<Text> {A1, A2, A3, A4, A5, A6, A7, A8, A9, A10,
										B1, B2, B3, B4, B5, B6, B7, B8, B9, B10,
										C1, C2, C3, C4, C5, C6, C7, C8, C9, C10};
			WordArray = new List<string> {twist, aware, mayor, swarm, smell, video, blast, shave, youth, peace,
								     	  shift, donor, awful, tough, hobby, wheel, style, tight, drown, abuse, 
										  stick, sweet, elect, brave, split, crime, clerk, penny, tribe, pound};

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
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			terminalInterface.SetActive(false);
			camScript.enabled = true;
			movScript.enabled = true;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.lockState = CursorLockMode.Locked;
		}
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
