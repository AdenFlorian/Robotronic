using UnityEngine;
using System.Collections;

public class Monster_Stump_1 : Monster {

	// Use this for initialization
	void Start () {
		levelId = Main.currentLevel;
		isDead = false;
		health = 1;
		moveVel = 0.03f;
		points = 100;
		zPos = 1.13f;
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

		transform.Rotate(Vector3.forward, 6f);	// rotate constantly

		//UpdateColor();

		UpdateMovement();
	}

	void UpdateMovement() {
		/**velX = 0;
		velY = 0;
		velZ = 0;**/
		if (Main.isPlayerAlive) {
			transform.position = Vector3.MoveTowards(transform.position, Main.player1.transform.position, moveVel);
			//transform.position.z = zPos;
		}
	}

	void UpdateColor() {
		//float r, g, b;
		//renderer.material.color -= new Color(0.0f, 0.1f, 0.1f);
	}
}
