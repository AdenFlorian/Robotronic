using UnityEngine;
using System.Collections;

public class Monster_Vasil_1 : Monster {

	// Use this for initialization
	void Start () {
		levelId = Main.currentLevel;
		isDead = false;
		health = 2;
		moveVel = 0.02f;
		points = 200;
		zPos = 1.75f;
	}
	
	// Update is called once per frame
	void Update () {
		if (levelId < (Main.currentLevel)) {
			Destroy(this.gameObject);
		}
		// upon death
		if (health <= 0) {
			//death1.Play();
			//death2.Play();
			Main.score += points;
			Main.monstersAlive--;
			Destroy(this.gameObject);
		}

		transform.LookAt(Main.player1.transform);	// rotates to face the player
		this.transform.rotation.eulerAngles.Set(0f,
												0f,
												transform.rotation.eulerAngles.z);

		//UpdateColor();

		UpdateMovement();
	}

	void UpdateMovement() {
		/**velX = 0;
		velY = 0;
		velZ = 0;**/
		if (Main.isPlayerAlive) {
			transform.position = Vector3.MoveTowards(transform.position, Main.player1.transform.position, moveVel);
			transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zPos);
		}
	}

	void UpdateColor() {
		//float r, g, b;
		//renderer.material.color -= new Color(0.0f, 0.1f, 0.1f);
	}
}