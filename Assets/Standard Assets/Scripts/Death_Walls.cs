using UnityEngine;
using System.Collections;

using System;

public class Death_Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (String.Compare(other.tag, "wall", false) == 0 || string.Compare(other.tag, "enemy", true) == 0) {
			
		} else {
			Destroy(other.gameObject);
		}
	}
}
