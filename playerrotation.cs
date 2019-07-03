using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrotation : MonoBehaviour {
	//private Transform playertrans;
	private Vector3 playerang;
	// Use this for initialization
	void Start () {
		//playertrans = this.transform;
		playerang = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		playerrotate ();	
	}

	void playerrotate(){
		float y = Input.GetAxis ("Mouse X");
		playerang.y += 2 * y;
		//playertrans.eulerAngles = playerang;
		float playery = playerang.y;
		this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, playery, this.transform.eulerAngles.z);
	}
}
