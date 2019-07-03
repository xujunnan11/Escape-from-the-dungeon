using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {
	public GameObject helpbutton;
	public GameObject storybutton;
	public GameObject playerstate;
	// Use this for initialization
	void Start () {
		playerstate = GameObject.FindGameObjectWithTag (tags.state);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartGame(){
		playerstate.GetComponent<playerstate> ().hp = 100;
		playerstate.GetComponent<playerstate> ().mp = 100;
		SceneManager.LoadScene ("Dungeons_1");
	}
	public void CloseGame(){
		Application.Quit ();
	}
	public void ClickHelp(){
		helpbutton.SetActive (true);
	}
	public void CloseHelp(){
		helpbutton.SetActive (false);
	}
	public void ClickStory(){
		storybutton.SetActive (true);
	}
	public void CloseStory(){
		storybutton.SetActive (false);
	}
}
