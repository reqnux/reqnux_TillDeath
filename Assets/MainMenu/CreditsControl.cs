using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsControl : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			SceneManager.LoadScene ("MainMenu");
	}
}
