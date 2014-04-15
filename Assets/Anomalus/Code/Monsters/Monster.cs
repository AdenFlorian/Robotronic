using UnityEngine;
using System.Collections;

public abstract class Monster : MonoBehaviour {

	public AudioSource hit1;
	public AudioSource hit2;
	public AudioSource death1;
	public AudioSource death2;
	public AudioSource ambient1;
	public AudioSource ambient2;

	protected float health;		// monster's starting health

	protected int points;	// how many points the monster is worth

	protected float moveVel;

	protected float velX;
	protected float velY;
	protected float velZ;

	protected float vel2X;
	protected float vel2Y;
	protected float vel2Z;

	protected Vector3 newPos;

	public float zPos;

	protected bool isHit;
	protected bool isDead;

	protected int deathCount = 0;

	public int levelId;

	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (string.Compare(other.tag, "bullet", true) == 0 || string.Compare(other.tag, "deathwall", true) == 0) {
			health--;
			renderer.material.color -= new Color(0.0f, 0.1f, 0.1f);
			Destroy(other.gameObject);
			//hit1.Play();
		}

		if (string.Compare(other.tag, "deathwall", true) == 0) {
			Main.monstersAlive--;
			Destroy(this.gameObject);
		}

	}
}
