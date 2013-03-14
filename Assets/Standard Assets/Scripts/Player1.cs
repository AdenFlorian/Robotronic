

using UnityEngine;
using System.Collections;

using System;

public class Player1 : MonoBehaviour {

	private float shootTimeLimit = 0f;		// doesn't work yet

	protected static float shootSpeed = 0.11f;
	
	private float velX;
	private float velY;
	private float velZ;

	// audio
	public AudioSource shoot1;
	
	//private float vel2X = 0;
	//private float vel2Y = 0;
	//private float vel2Z = 0;

	//public float angle = 0;

	// player speeds
    //public float normalSpeed = 5f;
	//public float runSpeed = 7f;
	private float moveVel = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// resetting velocities
		velX = 0;
		velY = 0;
		velZ = 0;

		shootTimeLimit -= Time.deltaTime;	// subtracts from shoot timer to limit how fast you can shoot

		// calculates movement
		UpdateMovement();

		// applys movement
		transform.Translate(velX, velY, 0f);

		// shoots
		UpdateShootingStuff();

		// kill all button
		if (Input.GetKeyDown(KeyCode.Q)) {
			Main.ClearMonsters();
			Main.ClearMines();
		}

		
	}

	void Shoot(float shootAngle) {
		// creates GameObject "clone" to hold the "Bullet" prefab
		GameObject clone;

		// instantiates "Bullet" prefab at the player's location with the player's rotation
		clone = Instantiate(Resources.Load("Bullet"), 
							transform.position += new Vector3(velX, velY, 0f),	
							transform.rotation) as GameObject;	
		clone.transform.Rotate(Vector3.forward, shootAngle);

		// plays shoot sound
		shoot1.Play();
		//shootTimeLimit = 1000f;		// doesn't work yet
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("PLAYER 1 ontriggerenter triggered");
		if (String.Compare(other.tag, "enemy", false) == 0) {
			KillPlayer();
		}
	}

	/**void OnCollisionEnter(Collision other) {
		Debug.Log("oncollisionenter triggered");
		if (String.Compare(other.collider.tag, "enemy", false) == 0) {
			KillPlayer();
		}
	}**/

	void KillPlayer() {
		Main.isPlayerAlive = false;
		Main.lives--;
		Destroy(this.gameObject);
	}



	void UpdateMovement() {
		if (Input.GetKey(KeyCode.W)) {
			velY = moveVel * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.S)) {
			velY = -moveVel * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.A)) {
			velX = moveVel * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.D)) {
			velX = -moveVel * Time.deltaTime;
		}
	}

	void UpdateShootingStuff() {
		// shooting loop; tests each condition until it is true, then executes and breaks loop
		while (true) {
			// for shooting in diagonals
			if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && (shootTimeLimit <= 0)) {
				Shoot(225f);
				shootTimeLimit = shootSpeed;
				break;
			}

			if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && (shootTimeLimit <= 0)) {
				Shoot(135f);
				shootTimeLimit = shootSpeed;
				break;
			}

			if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && (shootTimeLimit <= 0)) {
				Shoot(45f);
				shootTimeLimit = shootSpeed;
				break;
			}


			if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && (shootTimeLimit <= 0)) {
				Shoot(315f);
				shootTimeLimit = shootSpeed;
				break;
			}

			// shoots while key is held down, limited by shootTimeLimit
			if (Input.GetKey(KeyCode.UpArrow) && (shootTimeLimit <= 0)) {
				Shoot(180f);
				shootTimeLimit = shootSpeed;
				break;
			}

			if (Input.GetKey(KeyCode.DownArrow) && (shootTimeLimit <= 0)) {
				Shoot(0f);
				shootTimeLimit = shootSpeed;
				break;
			}

			if (Input.GetKey(KeyCode.LeftArrow) && (shootTimeLimit <= 0)) {
				Shoot(90f);
				shootTimeLimit = shootSpeed;
				break;
			}

			if (Input.GetKey(KeyCode.RightArrow) && (shootTimeLimit <= 0)) {
				Shoot(270f);
				shootTimeLimit = shootSpeed;
				break;
			}
			break;
		}
	}
}
