using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoattackandrun : MonoBehaviour {

	private Transform player;
	private Transform thispos;
	private Animator animator;
	private attackanddamage playerhp;
	public float attackdistance=2;
	public float searchdistance=20;
	public float speed = 3;
	public float attacktime = 3;
	private float attacktimer = 0;
	public float destorytime = 0;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (tags.player).transform;
		playerhp = player.GetComponent<attackanddamage> ();
		thispos = this.GetComponent<Transform> ();
		animator = this.GetComponent<Animator> ();
		attacktimer = attacktime;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerhp.hp <= 0) {
			animator.SetBool ("run", false);return;
		} 
		Vector3 targetpos = player.position;
		targetpos.y = transform.position.y;
		if (this.GetComponentInChildren<monsterattackanddamage> ().hp <= 0) {
		} else {
			transform.LookAt (targetpos);
		}
		float distance = Vector3.Distance (targetpos, transform.position);
		if (distance <= attackdistance) {
			attacktimer += Time.deltaTime;
			if (attacktimer > attacktime) {
				animator.SetTrigger ("attack");
				attacktimer = 0;
				player.GetComponent<attackanddamage> ().TakeDamage (player.GetComponent<attackanddamage> ().monsterATK);
			} else {
				animator.SetBool ("run", false);
			}
		}
		if (distance <= searchdistance && distance > attackdistance) {
				attacktimer = attacktime;
				if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Zombie Running")) {
					transform.position += transform.forward * speed * Time.deltaTime;
				}
				animator.SetBool ("run", true);
		} else {
			animator.SetBool ("run", false);
		}
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Dying")) {
			animator.SetBool ("dead", false);
			Destroy (gameObject, 8.0f);
			this.GetComponent<monsterdropitem> ().Drop ();
			this.GetComponent<Rigidbody> ().useGravity = false;
			this.GetComponent<BoxCollider> ().enabled = false;
			this.GetComponent<autoattackandrun> ().enabled = false;
		}
	}
}
