using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private int selectedChoice;		// 1, 2, or 3

	public GameObject mainScene;

	public GameObject choice1;		// used to hold the Score GUI Text GameObject

	public GameObject choice2;

	public GameObject choice3;

	// Use this for initialization
	void Start () {
		selectedChoice = 1;		// main menu starts with choice 1 selected
	}

	// Update is called once per frame
	void Update() {

		choice1.guiText.fontSize = 30;
		choice2.guiText.fontSize = 30;
		choice3.guiText.fontSize = 30;
		choice1.guiText.material.color = new Color(1f, 1f, 1f);
		choice2.guiText.material.color = new Color(1f, 1f, 1f);
		choice3.guiText.material.color = new Color(1f, 1f, 1f);

		HighlightSelected(selectedChoice);

		while (true) {
			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
				selectedChoice++;
				break;
			}

			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
				selectedChoice--;
				break;
			}

			if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
				ExecuteChoice(selectedChoice);
				break;
			}
			break;
		}

		if (selectedChoice > 3) {
			selectedChoice = 1;
		} else if (selectedChoice < 1) {
			selectedChoice = 3;
		}
	}

	void HighlightSelected(int choice) {
		switch (choice) {
			case 1: choice1.guiText.fontSize += 3;
				choice1.guiText.material.color = new Color(0.0f, 1f, 0f);
				break;
			case 2: choice2.guiText.fontSize += 3;
				choice2.guiText.material.color = new Color(0.0f, 1f, 0f);
				break;
			case 3: choice3.guiText.fontSize += 3;
				choice3.guiText.material.color = new Color(0.0f, 1f, 0f);
				break;
		}
	}

	void ExecuteChoice(int choice) {
		switch (choice) {
			case 1: mainScene.SetActive(true);
				this.gameObject.SetActive(false);
				break;
			case 2: break;
			case 3: break;
		}
	}

}
