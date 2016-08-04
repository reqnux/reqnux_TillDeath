using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayFadeInEffect : MonoBehaviour {

    [SerializeField] float fadeInTime;
    Image image;
    float tick = 0.005f;
    float timeBetweenTicks;
    float lastTickTime;

	void Start () {
        image = GetComponent<Image>();
        timeBetweenTicks = fadeInTime * tick;
        lastTickTime = Time.timeSinceLevelLoad;
	}
	
	void Update () {
        if (Time.timeSinceLevelLoad > lastTickTime + timeBetweenTicks)
        {
            lastTickTime = Time.timeSinceLevelLoad;
            image.color = new Color(0, 0, 0, image.color.a - tick);
        }

        if (image.color.a <= 0)
            Destroy(gameObject);
	}
}
