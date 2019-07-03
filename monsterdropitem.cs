using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterdropitem : MonoBehaviour {
	public GameObject mpball;
	public GameObject hpball;
	private int rand;
	private GameObject dropitem;

	// Use this for initialization
	void Start () {
		rand = Random.Range (0, 100);
	}
	
	// Update is called once per frame
	public void Drop() {
		if (rand >= 0 && rand <= 50)
			dropitem = mpball;
		else
			dropitem = hpball;
		Vector3 droppos = new Vector3 (this.transform.position.x, 1f, this.transform.position.z);
		GameObject.Instantiate (dropitem, droppos, Quaternion.identity);
	}
}
