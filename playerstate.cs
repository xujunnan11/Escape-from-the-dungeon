using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstate : MonoBehaviour {
	public float hp;
	public float mp;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
