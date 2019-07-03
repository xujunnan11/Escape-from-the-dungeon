using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
	public float gunattack = 10;
	public AudioClip fire;
	private AudioSource sound;
	private float timer;
	private GameObject player;

	// Use this for initialization
	void Start () {
		sound = this.GetComponent<AudioSource> ();
		sound.clip = fire;
		timer = 0;
		player = GameObject.FindGameObjectWithTag (tags.player);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)){
			if (player.GetComponent<attackanddamage> ().mp > 0) {
				timer += Time.deltaTime;
				if (timer > 0.25F) {
					sound.Play ();
					timer = 0;
				}
			} else {
			}
		}
	}
	void OnParticleCollision(GameObject targetobject){
		if (targetobject.tag == "Monster") {
			targetobject.GetComponent<attackanddamage> ().TakeDamage (gunattack);	
		}
	}
}
