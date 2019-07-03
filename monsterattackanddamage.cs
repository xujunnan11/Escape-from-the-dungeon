using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterattackanddamage : attackanddamage {

	private Transform player;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag (tags.player).transform;
	}

	public void monsterattack(){
		if (Vector3.Distance (transform.position, player.position) < attackdistance) {
			player.GetComponent<attackanddamage> ().TakeDamage (monsterATK);
		}
	}

}
