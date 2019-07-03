using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour {
	private GameObject player;
	private GameObject playerstate;
	private string thisscene;
	private int nomber;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (tags.player);
		playerstate = GameObject.FindGameObjectWithTag (tags.state);
		player.GetComponent<attackanddamage> ().hp = playerstate.GetComponent<playerstate> ().hp;
		player.GetComponent<attackanddamage> ().mp = playerstate.GetComponent<playerstate> ().mp;
		thisscene = SceneManager.GetActiveScene ().name;
		string no = thisscene.Substring (9);
		nomber = int.Parse (no) + 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(){
		playerstate.GetComponent<playerstate> ().hp = player.GetComponent<attackanddamage> ().hp;
		playerstate.GetComponent<playerstate> ().mp = player.GetComponent<attackanddamage> ().mp;
		SceneManager.LoadSceneAsync (nomber);
	}
}
