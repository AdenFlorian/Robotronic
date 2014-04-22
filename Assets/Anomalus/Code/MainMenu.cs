using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainScene;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			mainScene.SetActive(true);
			this.gameObject.SetActive(false);
		}

	}

}
