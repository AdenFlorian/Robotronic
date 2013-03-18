using UnityEngine;
using System.Collections;

public class LevelStruct: ScriptableObject {

	[HideInInspector]
	public int current;
	[HideInInspector]
	public int monster_stump_1;
	[HideInInspector]
	public int monster_vasil_1;
	[HideInInspector]
	public int monster_saucer_1;
	[HideInInspector]
	public int monster_hulk_1;
	[HideInInspector]
	public int mine_box_1;
	[HideInInspector]
	public int mine_spikeball_1;
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
		totalMonsters = monster_stump_1 + monster_vasil_1 + monster_saucer_1 + monster_hulk_1 + mine_box_1 + mine_spikeball_1;
	}

	

}
