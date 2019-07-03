using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : MonoBehaviour {
	public GameObject wall;
	public GameObject keycanves;
	public GameObject player;
	private bool password;

	// Use this for initialization
	void Start () {
		password = false;
		player = GameObject.FindGameObjectWithTag (tags.player);
		keycanves.GetComponent<Canvas> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (password == true) {
			wall.transform.position = Vector3.Lerp (wall.transform.position, wall.transform.position + wall.transform.up * 2, Time.deltaTime );
			if (wall.transform.position.y >= 3)
				password = false;
		}
		if (Vector3.Distance (wall.transform.position, player.transform.position) <= 1) {
			keycanves.GetComponent<Canvas> ().enabled = true;
			Cursor.visible = true;
		}
		else
			keycanves.GetComponent<Canvas> ().enabled = false;
	}

	public void inputkey(string inputtext){
		if (inputtext == "20150805129") {
			password = true;
			keycanves.GetComponent<Canvas> ().enabled = false;
		} else {
		}
	}

}
