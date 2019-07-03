using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class slidercontrol : MonoBehaviour {
	public GameObject player;
	public Slider HpSlider;
	public Slider MpSlider;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (tags.player);
	}

	// Update is called once per frame
	void Update () {
		HpSlider.value = player.GetComponent<attackanddamage> ().hp;
		MpSlider.value = player.GetComponent<attackanddamage> ().mp;
		if (HpSlider.value <= 0) {
			player.GetComponent<playerrotation> ().enabled = false;
			Cursor.visible = true;
			SceneManager.LoadScene ("Lose");
		}
	}
}
