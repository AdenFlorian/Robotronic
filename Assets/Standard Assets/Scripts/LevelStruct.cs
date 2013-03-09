using UnityEngine;
using System.Collections;

public class LevelStruct: ScriptableObject {

	[HideInInspector]
	public int current;
	[HideInInspector]
	public int stumps;
	[HideInInspector]
	public int vasils;
	[HideInInspector]
	public int saucer1s;
	[HideInInspector]
	public int mine_boxes;
	[HideInInspector]
	public int mine_spikeballs;
	[HideInInspector]
	public string name;
	[HideInInspector]
	public string groundMaterial;
	[HideInInspector]
	public string wallMaterial;
	[HideInInspector]
	public string skyboxMaterial;
	[HideInInspector]
	public string spotlightColor;
	[HideInInspector]
	public int totalMonsters;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sumMonsters() {
		totalMonsters = stumps + vasils + saucer1s + mine_boxes + mine_spikeballs;
	}

	

}
