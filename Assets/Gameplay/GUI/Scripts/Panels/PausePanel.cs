using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {

    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

}
