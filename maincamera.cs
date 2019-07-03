using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamera : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (tags.player);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 beginpos = player.transform.position + player.transform.forward * -2 + player.transform.up * 2;
		Vector3 endpos = player.transform.position + player.transform.forward * -0.1f + player.transform.up * 2;
		Vector3 pos1 = Vector3.Lerp (beginpos, endpos, 0.25f);
		Vector3 pos2 = Vector3.Lerp (beginpos, endpos, 0.5f);
		Vector3 pos3 = Vector3.Lerp (beginpos, endpos, 0.75f);
		Vector3[] posarray = new Vector3[]{ beginpos, pos1, pos2, pos3, endpos };
		Vector3 targetpos = posarray [0];
		for (int i = 0; i < 5; i++) {
			RaycastHit hit;
			if (Physics.Raycast (posarray [i], player.transform.position - posarray [i], out hit)) {
				if (hit.collider.tag != tags.player)
					continue;
				else {
					targetpos = posarray [i];
					break;
				}
			} else {
				targetpos = posarray [i];
				break;
			}
		}
		Quaternion nowrotation = transform.rotation;
		Vector3 point = player.transform.position + transform.up * 1;
		transform.LookAt (point);
		transform.rotation = Quaternion.Lerp (nowrotation, transform.rotation, Time.deltaTime * 3);
		transform.position = Vector3.Lerp (transform.position, targetpos, Time.deltaTime * 3);
	}
}
