using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReloadIndicator : MonoBehaviour {

    Image indicator;
    Player player;

    float lastUpdateTime;
    float timeBetweenUpdates = 0.1f;
    float updateAmount;

	void Start () {
        indicator = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void Update () {
        transform.position = Input.mousePosition;

        if (player.CurrentWeapon.Reloading)
        {
            updateIndicator();
        }
        else
            indicator.fillAmount = 0;
	}

    void updateIndicator()
    {
        if (indicator.fillAmount == 0)
            updateAmount = timeBetweenUpdates / player.CurrentWeapon.TimeToReloadEnd;

        if (Time.timeSinceLevelLoad > lastUpdateTime + timeBetweenUpdates)
        {
            lastUpdateTime = Time.timeSinceLevelLoad;
            indicator.fillAmount += updateAmount;
        }
    }
}
