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

	private GameObject stump;
	private GameObject vasil;
	private GameObject mine_box;

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
	 * 6. Again in SpawnMonsters(), if your monster is not a mine, and not invincible, ad it to the first line (Main.monstersAlive = ...)
	 * 6. in MonsterSpawner.cs, add a function to make that monster (copy an existing function if ouy want)
	 * 7. Then add a line in SpawnMonsters() to call the new function with the correct argument
	 * 8. Finally, in Main.cs > Start() > add how many monsters you want to spawn in each level to the level definitions
	 * 9. Make sure all scripts are saved
	 * **/

	public void SpawnMonsters(int stumps, int vasils, int saucer1s, int mine_boxes, int mine_spikeballs) {
		Main.monstersAlive = stumps + vasils + saucer1s;	// When all these monsters are dead, the level is over

		makeMineBoxes(mine_boxes);

		makeMineSpikeBalls(mine_spikeballs);
		
		makeStumps(stumps);

		makeVasils(vasils);

		makeSaucer1s(saucer1s);

	}

	void makeStumps(int amount) {
		for (int i = 0; i < amount; i++) {
			stump = Instantiate(Resources.Load("monster_stump"),
								FindNextSpawn(1.13f),	// position.z
								Random.rotation) as GameObject;
		}
	}

	void makeVasils(int amount) {
		for (int i = 0; i < amount; i++) {
			vasil = Instantiate(Resources.Load("monster_vasil"),
								FindNextSpawn(1.1f),	// position.z
								transform.rotation) as GameObject;
		}
	}

	void makeSaucer1s(int amount) {
		for (int i = 0; i < amount; i++) {
			vasil = Instantiate(Resources.Load("saucer1Parent"),	// the name of the prefab
								FindNextSpawn(0.88f),	// position.z is the argument being passed
								transform.rotation) as GameObject;
		}
	}

	void makeMineBoxes(int amount) {
		for (int i = 0; i < amount; i++) {
			mine_box = Instantiate(Resources.Load("mine_box"),
								FindNextSpawn(0.79f),// position.z
								transform.rotation) as GameObject;
		}
	}

	void makeMineSpikeBalls(int amount) {
		for (int i = 0; i < amount; i++) {
			mine_box = Instantiate(Resources.Load("mine_spikeball"),
								FindNextSpawn(0.79f),// position.z
								transform.rotation) as GameObject;
		}
	}

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
