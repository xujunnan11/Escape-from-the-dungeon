using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimatorcontrol : MonoBehaviour {

	private Animator animator;
	private float time;
	private float idletime = 5;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		idletime = idletime - Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.W)) {
			animator.SetBool ("walk", true);
			animator.SetBool ("forward", true);
			if (Time.realtimeSinceStartup - time <= 1.0f) {
				animator.SetBool ("run", true);
			}
			time = Time.realtimeSinceStartup;
			animator.SetBool ("timeover", false);
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			animator.SetBool ("walk", false);
			animator.SetBool ("forward", false);
			animator.SetBool ("run", false);
			idletime = 5;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			animator.SetBool ("backward", true);
			animator.SetBool ("timeover", false);
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			animator.SetBool ("backward", false);
			idletime = 5;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			animator.SetBool ("left", true);
			animator.SetBool ("timeover", false);
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			animator.SetBool ("left", false);
			idletime = 5;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			animator.SetBool ("right", true);
			animator.SetBool ("timeover", false);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			animator.SetBool ("right", false);
			idletime = 5;
		}
		if (idletime<=0&&animator.GetCurrentAnimatorStateInfo(0).IsName("Rifle Idle")) {
			animator.SetBool ("timeover", true);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("jump");
		}
	}
}
