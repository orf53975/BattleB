﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoginControllerScript : MonoBehaviour {
	public InputField userName;
	public InputField password;
	public Button signinBtn;
	public Button signupBtn;
	public Text responseText;
	public string name;
	public int sc;

	private List<string[]> allUsers;
	private HttpControllerScript httpController;

	private bool isExist;

	// Use this for initialization
	void Start () {
		httpController = new HttpControllerScript ();
		responseText.enabled = false;
//		GetPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.U)){
			allUsers = httpController.GetPlayers ();
			ShowPlayers ();

		} else if (Input.GetKeyDown(KeyCode.P)){
			httpController.PutScore(name, sc);
		}
	
	}

	private void ShowPlayers(){
		for (int i = 0; i < allUsers.Count; i++) {
//			Debug.Log (i);
			Debug.Log (allUsers [i] [1]);
		}
	}

	public void LoginManagement(){
		string user = userName.text;
		string pw = password.text;

		httpController.CheckExistingUser (this, user, pw);
	}

	public void SetResponseText(string text){
		responseText.enabled = true;
		responseText.text = text;
	}

	public void LoggedIn(){
		Application.LoadLevel ("NetworkLobby");
	}

	public void GoToSignUp(){
		Application.LoadLevel ("SignUpScene");
	}
}
