using UnityEngine;
using System.Collections;

public class CameraMain : MonoBehaviour {

	private float xMin = -3.8f;	// -.34 mid
	private float xMax = 3.126f;
	private float yMin = -30.5f;	// -27.6 mid
	private float yMax = -25f;
	private float zMin = 31.5f;		// 33.4 mid
	private float zMax = 35f;

	private float xMinRot = 316F;
	private float xMaxRot = 327F;
	private float yMinRot = 176f;
	private float yMaxRot = 183f;
	//private float zMinRot = ;
	//private float zMaxRot = ;

	private float newX;
	private float newY;
	private float newZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Main.isPlayerAlive) {
			newX = ((((Main.player1.transform.position.x + 10f) / 20f) * Mathf.Abs(xMin - xMax)) + xMin);
			newY = ((((Main.player1.transform.position.y + 10f) / 20f) * Mathf.Abs(yMin - yMax)) + yMin);
		}
		//transform.position.z = ;
		//transform.eulerAngles.x = ;
		//transform.eulerAngles.y = ;

		transform.position = (new Vector3(newX, newY, transform.position.z));
	}
}
