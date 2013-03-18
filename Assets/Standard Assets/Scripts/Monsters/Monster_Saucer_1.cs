using UnityEngine;
using System.Collections;

public class Monster_Saucer_1 : Monster {

	public GameObject monster_saucer_1Parent;

	private float scaleCounter;
	private bool isScaleCounterAscending;
	private float newScale;

	public float maxScale;
	public float minScale;
	public float currentScale;

	// Use this for initialization
	void Start () {
		levelId = Main.currentLevel;
		isDead = false;
		health = 2;
		moveVel = 0.02f;
		points = 175;
		zPos = 1.1f;
		scaleCounter = 0;
		maxScale = 1.5f;
		minScale = 1f;
		currentScale = 1f;
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

		//transform.LookAt(player1.transform);	// rotates to face the player

		

		

		//UpdateColor();

		UpdateMovement();

		UpdateAnimation();
	}

	void UpdateAnimation() {
		monster_saucer_1Parent.transform.Rotate(Vector3.forward, 4.5f);	// rotate constantly

		if (currentScale <= minScale) {
			//scaleCounter = 0f;
			isScaleCounterAscending = true;
			newScale = 0.5f * Time.deltaTime;
		} else if (currentScale >= maxScale) {
			//scaleCounter = 1f;
			isScaleCounterAscending = false;
			newScale = -0.5f * Time.deltaTime;
		}
		if (isScaleCounterAscending) { scaleCounter += Time.deltaTime; } else { scaleCounter -= Time.deltaTime; }

		//newScale = 1f * Time.deltaTime;

		//newScale = 1f * Time.deltaTime;



		// adjust scale
		currentScale += newScale;
		monster_saucer_1Parent.transform.localScale += new Vector3(newScale, newScale, 0);
	}

	void UpdateMovement() {
		/**velX = 0;
		velY = 0;
		velZ = 0;**/
		if (Main.isPlayerAlive) {
			monster_saucer_1Parent.transform.position = Vector3.MoveTowards(monster_saucer_1Parent.transform.position, Main.player1.transform.position, moveVel);
		}
	}

	void UpdateColor() {
		//float r, g, b;
		//renderer.material.color -= new Color(0.0f, 0.1f, 0.1f);
	}
}
