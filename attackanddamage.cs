using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackanddamage : MonoBehaviour {

	public float hp = 100;
	public float mp = 100;
	public float attack = 10;
	public float attackdistance=20;
	public float monsterATK=5;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}

	public virtual void TakeDamage(float damage){
		hp -= damage;
		if (hp > 0) {
			animator.SetTrigger ("damage");
		}
		else {
			animator.SetBool ("dead", true);
			animator.SetTrigger ("dead");
		}
	}
}
