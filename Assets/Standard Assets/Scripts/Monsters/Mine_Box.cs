using UnityEngine;
using System.Collections;

public class Mine_Box : Monster {

	private float alphaColor;
	private float alphaColorChange;

	// Use this for initialization
	void Start () {
		levelId = Main.currentLevel;
		isDead = false;
		health = 1;
		moveVel = 0.00f;
		points = 50;
		zPos = 0.79f;
		alphaColor = 1f;
		alphaColorChange = -0.1f;
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
			//monstersAlive--;
			Destroy(this.gameObject);
		}

		//transform.Rotate(Vector3.forward, 6f);	// rotate constantly

		UpdateColor();

		//UpdateMovement();
	}

	void UpdateColor() {

		//make it pulse slightly
		// interpolate this shit (smooth it out)
		if (alphaColor >= 1f) {
			alphaColorChange = -00.8f;
		}

		if (alphaColor <= 0.55f) {
			alphaColorChange = 00.8f;
		}
		alphaColor += alphaColorChange * Time.deltaTime;
		renderer.material.color += new Color(0f, alphaColorChange * Time.deltaTime, 0f);
		

	}
}
