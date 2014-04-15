using UnityEngine;
using System.Collections;

using System;

public class BulletSpeed : MonoBehaviour {

	private float bulletSpeed = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Time.deltaTime * bulletSpeed * -transform.up;
	}
}
