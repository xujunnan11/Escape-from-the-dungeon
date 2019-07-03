using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getitem : MonoBehaviour {
	private GameObject player;
	public float speed = 8;
	private bool startget = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (tags.player);
	}
	
	// Update is called once per frame
	void Update () {
		if (startget) {
			transform.position = Vector3.Lerp (transform.position, player.transform.position + Vector3.up, speed * Time.deltaTime);
			if (Vector3.Distance (transform.position, player.transform.position + Vector3.up) < 0.5f) {
				if (this.name=="mpball(Clone)") {
					if (player.GetComponent<attackanddamage> ().mp + 20 > 100) {
						player.GetComponent<attackanddamage> ().mp = 100;
					} else {
						player.GetComponent<attackanddamage> ().mp += 20;
					}
				} else {
					if (player.GetComponent<attackanddamage> ().hp + 20 > 100) {
						player.GetComponent<attackanddamage> ().hp = 100;
					} else {
						player.GetComponent<attackanddamage> ().hp += 20;
					}
				}
				Destroy (this.gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == tags.player) {
			startget = true;
		}
	}
	
}