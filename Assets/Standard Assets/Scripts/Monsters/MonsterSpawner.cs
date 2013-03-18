using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

	/**
	 * spawning procedure: (not really utilized yet)
	 * 
	 * 1. mines
	 * 2. destroyable monsters
	 * 3. indestructible monsters
	 * 4. humans
	 * 5. other
	 * 
	 * **/

	private GameObject monster_stump_1;
	private GameObject monster_vasil_1;
	private GameObject monster_saucer_1;
	private GameObject monster_hulk_1;
	private GameObject mine_box_1;
	private GameObject mine_spikeball_1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/** HOW TO ADD NEW MONSTERS/MINES **
	 * 1. Make a prefab for the monster with the monster_ prefix (can copy an existing monster prefab, then change name a whatever
	 * 1.2 Copy an existing monster_ script, rename for new monster and attach to new monster prefab
	 * 1.3 Open new script in editor, change class name to match script name and anything else you want
	 * 2. add an int variable to LevelStruct.cs named "monster_mymonsters"
	 * 3. in the sumMonsters() function, add your monster to that line
	 * 4. in Main.cs > LevelMaker() > the line monsterSpawner.SpawnMonsters, 
	 *    add an argument to the end with your monster variable you created in LevelStruct.cs
	 * 5. in MonsterSpawner.cs (this one) > SpawnMonsters(), add new monster as argument
	 * 5.2 add a class variable for the new monster
	 * 6. Again in SpawnMonsters(), if your monster is not a mine, and not invincible, ad it to the first line (Main.monstersAlive = ...)
	 * 6. in MonsterSpawner.cs, add a function to make that monster (copy an existing function if ouy want)
	 * 7. Then add a line in SpawnMonsters() to call the new function with the correct argument
	 * 8. Finally, in Main.cs > Start() > add how many monsters you want to spawn in each level to the level definitions
	 * 9. Make sure all scripts are saved
	 * **/

	public void SpawnMonsters(	int monster_stump1_amount, 
								int monster_vasil1_amount, 
								int monster_saucer1_amount,
								int monster_hulk_1_amount,
								int mine_box_1es, 
								int mine_spikeball1_amount) {

		//killable monsters
		Main.monstersAlive = monster_stump1_amount + monster_vasil1_amount + monster_saucer1_amount;	// When all these monsters are dead, the level is over

		// make mines first

		makeMine_Box_1(mine_box_1es);

		makeMine_Spikeball_1(mine_spikeball1_amount);

		// make humans second

		// make normal monsters third
		
		makeMonster_Stump_1(monster_stump1_amount);

		makeMonster_Vasil_1(monster_vasil1_amount);

		makeMonster_Saucer_1(monster_saucer1_amount);

		// make invincible monsters (hulks) last

		makeMonster_Hulk_1(monster_hulk_1_amount);

	}

	/** monsterArr[r,c]
	 * 
	 * 0 - monster_stump1_amount
	 * 1 - monster_vasil1_amount
	 * 2 - monster_saucer1_amount
	 * 
	 * hulks start at [10,i]
	 * 
	 * 10 - monster_hulk_1
	 * 
	 * mines start at [50,i]
	 * 
	 * 50 - mine_box_1es
	 * 51 - mine_spikeball1_amount
	 * 
	 * humans start at [90,i]
	 * 
	 * 90 - human_man
	 * 91 - human_woman
	 * 92 - human_boy
	 * 93 - human_girl
	 * 94 - human_grandpa
	 * 95 - human_grandma
	 * 96 - human_baby
	 * 
	 * **/

	/** BEGIN MONSTERS **/

	void makeMonster_Stump_1(int amount) {
		for (int i = 0; i < amount; i++) {
			monster_stump_1 = Instantiate(Resources.Load("monster_stump_1"),
								FindNextSpawn(1.13f),	// position.z
								Random.rotation) as GameObject;
			Main.monsterArr[0,i] = monster_stump_1;
		}
	}

	void makeMonster_Vasil_1(int amount) {
		for (int i = 0; i < amount; i++) {
			monster_vasil_1 = Instantiate(Resources.Load("monster_vasil_1"),
								FindNextSpawn(1.75f),	// position.z
								transform.rotation) as GameObject;
			Main.monsterArr[1,i] = monster_vasil_1;
		}
	}

	void makeMonster_Saucer_1(int amount) {
		for (int i = 0; i < amount; i++) {
			monster_saucer_1 = Instantiate(Resources.Load("monster_saucer_1"),	// the name of the prefab
								FindNextSpawn(0.88f),	// position.z is the argument being passed
								transform.rotation) as GameObject;
			Main.monsterArr[2,i] = monster_saucer_1;
		}
	}

	/** END MONSTERS **/

	/** BEGIN HULKS **/

	// hulks are invincible monsters

	void makeMonster_Hulk_1(int amount) {
		for (int i = 0; i < amount; i++) {
			monster_hulk_1 = Instantiate(Resources.Load("monster_hulk_1"),
								FindNextSpawn(Monster_Hulk_1.zPos),	// position.z
								transform.rotation) as GameObject;
			Main.monsterArr[10, i] = monster_hulk_1;
		}
	}

	/** END HULKS **/

	/** BEGIN MINES **/

	void makeMine_Box_1(int amount) {
		for (int i = 0; i < amount; i++) {
			mine_box_1 = Instantiate(Resources.Load("mine_box_1"),
								FindNextSpawn(0.79f),// position.z
								transform.rotation) as GameObject;
			Main.monsterArr[50,i] = mine_box_1;
		}
	}

	void makeMine_Spikeball_1(int amount) {
		for (int i = 0; i < amount; i++) {
			mine_spikeball_1 = Instantiate(Resources.Load("mine_spikeball_1"),
								FindNextSpawn(0.79f),// position.z
								transform.rotation) as GameObject;
			Main.monsterArr[51,i] = mine_spikeball_1;
		}
	}

	/** END MINES **/

	/** BEGIN HUMANS **/

	// humans can be collected by the player for points
	// humans can be killed by ubers or converted by special monsters (physcic monster things)

	/** END HUMANS **/

	Vector3 FindNextSpawn(float newZ) {
		Vector3 nextSpawn = new Vector3();

		// gets random x and y floats that are not inside the player start box
		do {
			nextSpawn.x = Random.Range(-8.5f, 8.5f);
		} while (nextSpawn.x > -2 && nextSpawn.x < 2);
		do {
			nextSpawn.y = Random.Range(-8.5f, 8.5f);
		} while (nextSpawn.y > -2 && nextSpawn.y < 2);
		//nextSpawn.z = Random.Range(-8.5f, 8.5f);

		nextSpawn.z = newZ;

		return nextSpawn;
	}
}
