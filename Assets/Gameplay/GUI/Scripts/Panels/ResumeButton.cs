using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {

    public void resume() 
    {
        GameObject.Find("PausePanel").SetActive(false);
	}
}
