using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour {
	public GameObject terminalInterface;
	public GameObject loginScreen;
	public GameObject bypassScreen;
	public GameObject terminalMenu;
	public GameObject interactUI;
	public CameraScript camScript;
	public MovementScript movScript;
	public TextClickScript txtScript;
	public KeyScript xScript;
	public Button loginButton;
	public Button bypassButton;
	public InputField usernameField;
	public InputField passwordField;
	public GameObject player;
	public GameObject cam;
	public bool doesRequireLogin;
	public string username;
	public string password;
	public GameObject wordList;
	public AudioSource button1;
	public AudioSource button2;
	public Text SimilarityRatingText;
	public Text A1, A2, A3, A4, A5, A6, A7, A8, A9, A10,
				B1, B2, B3, B4, B5, B6, B7, B8, B9, B10,
				C1, C2, C3, C4, C5, C6, C7, C8, C9, C10;
	public bool success;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		movScript = player.GetComponent<MovementScript>();

		cam = GameObject.FindGameObjectWithTag("MainCamera");
		camScript = cam.GetComponent<CameraScript>();

		txtScript = wordList.GetComponent<TextClickScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
