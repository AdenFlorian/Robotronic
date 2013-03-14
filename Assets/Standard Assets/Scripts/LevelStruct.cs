using UnityEngine;
using System.Collections;

public class LevelStruct: ScriptableObject {

	[HideInInspector]
	public int current;
	[HideInInspector]
	public int monster_stump1_amount;
	[HideInInspector]
	public int monster_vasil1_amount;
	[HideInInspector]
	public int monster_saucer1_amount;
	[HideInInspector]
	public int mine_box_1es;
	[HideInInspector]
	public int mine_spikeball1_amount;
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
		totalMonsters = monster_stump1_amount + monster_vasil1_amount + monster_saucer1_amount + mine_box_1es + mine_spikeball1_amount;
	}

	

}
