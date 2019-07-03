using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

	public int speed = 2;
	public int walktype;
	private Animator animator;
	private Rigidbody rig;
	private float time;
	private bool ongournd = false;
	private float jumptimer;
	private bool jump = false;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rig = this.GetComponent<Rigidbody> ();
		jumptimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Rifle Run To Dying")) {
		}
		//if(animator.GetCurrentAnimatorStateInfo(0).IsName(""))
		else{
			if (Input.GetKeyDown (KeyCode.W)) {
				if (Time.realtimeSinceStartup - time <= 1.0f) {
					walktype = 1;
				} else
					walktype = 0;
				time = Time.realtimeSinceStartup;
			}

			if (Input.GetKey (KeyCode.W)) {
				if (walktype == 1) {
					transform.position += transform.forward * speed * Time.deltaTime * 3 / 2;
				} else {
					transform.position += transform.forward * speed * Time.deltaTime;
				}
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.position += transform.forward * speed * Time.deltaTime * -7 / 10;
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.position += transform.right * speed * Time.deltaTime * -1;
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.position += transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				jump = true;
			}
			if (jump) {
				jumptimer += Time.deltaTime;
				if (jumptimer >= 0.3f && ongournd == true){
					rig.velocity = new Vector3 (0f, 6f, 0f);
					ongournd = false;
					jumptimer = 0;
					jump = false;
				}
			}
		}
	}
	void OnCollisionEnter(Collision something){
		if (something.gameObject.tag == tags.gournd) {
			ongournd = true;	
		}
	}
}
