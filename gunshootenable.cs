using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunshootenable : MonoBehaviour {
	private GameObject bullet;
	private GameObject player;
	public GameObject maincam;
	public GameObject Geo;
	public GameObject Hit;
	public GameObject gun;
	// Use this for initialization
	void Start () {
		bullet = GameObject.FindGameObjectWithTag (tags.bullet);
		player = GameObject.FindGameObjectWithTag (tags.player);
		bullet.gameObject.SetActive (false);
		gun.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (player.GetComponent<attackanddamage> ().mp > 0) {
				bullet.gameObject.SetActive (true);
				player.GetComponent<attackanddamage> ().mp -= Time.deltaTime * 2;
			} else {
				bullet.gameObject.SetActive (false);
			}
			gun.SetActive (true);
			maincam.SetActive (false);
			Geo.SetActive (false);
			Hit.SetActive (false);
		}
		if (Input.GetMouseButtonUp (0)) {
			bullet.gameObject.SetActive (false);
			maincam.SetActive (true);
			Geo.SetActive (true);
			Hit.SetActive (true);
			gun.SetActive (false);
		}
		if (Input.GetMouseButton (1)) {
			gun.SetActive (true);
			maincam.SetActive (false);
			Geo.SetActive (false);
			Hit.SetActive (false);
		}
		if (Input.GetMouseButtonUp (1)) {
			maincam.SetActive (true);
			gun.SetActive (false);
			Geo.SetActive (true);
			Hit.SetActive (true);
		}
	}
}
