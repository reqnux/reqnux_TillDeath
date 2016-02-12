using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneButton : MonoBehaviour {

    public void loadScene(string sceneName)
    {
        // "does scene exists" check missing
        SceneManager.LoadScene(sceneName);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
