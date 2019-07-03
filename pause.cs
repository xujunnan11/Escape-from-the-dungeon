using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {
	public Texture buttontexture;
	public bool isgamepause;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (tags.player);
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Cursor.visible = true;
			stop ();
		}
	}
	void OnGUI(){
		if (!isgamepause)
			return;
		GUIStyle bs = new GUIStyle ();
		bs.normal.background = (Texture2D)buttontexture;
		bs.normal.textColor = Color.black;
		bs.fontSize = 20;
		bs.alignment = TextAnchor.MiddleCenter;
		GUILayout.BeginArea (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 200, 200, 400));
		GUILayout.BeginVertical ();
		if (isgamepause) {
			if (GUILayout.Button ("继续游戏", bs ,GUILayout.Height (100), GUILayout.Width (200))) {
				start ();
				Cursor.visible = false;
				isgamepause = false;
			}
			if (GUILayout.Button ("返回菜单",bs, GUILayout.Height (100))) {
				start ();
				SceneManager.LoadScene ("StartScene");
			}
			if (GUILayout.Button ("退出游戏", bs,GUILayout.Height (100))) {
				Application.Quit ();
			}
		}
	}
	void stop(){
		Time.timeScale = 0;
		isgamepause = true;
		player.GetComponent<playerrotation> ().enabled = false;
		player.GetComponent<gunshootenable> ().enabled = false;
	}
	void start(){
		Time.timeScale = 1;
		player.GetComponent<playerrotation> ().enabled = true;
		player.GetComponent<gunshootenable> ().enabled = true;
	}
}
