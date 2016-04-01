using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clock : MonoBehaviour {

    [SerializeField]
    private Text clockText;
    private float lastUpdateTime = 0;
    private int minutes;
    private int seconds;
    private float modulo;

    private bool stopped;

    void Awake() 
    {
        clockText = GetComponent<Text>();
    }

    void Start()
    {
        GameManager.gameStopEvent += stopClock;
    }

    void OnDisable()
    {
        GameManager.gameStopEvent -= stopClock;
    }

    void Update () 
    {
        if (!stopped && Time.time > lastUpdateTime + 1) 
        {
            lastUpdateTime = Time.time;
            if (clockText.enabled)
                clockText.text = Formatter.secondsToClockText(Mathf.FloorToInt(Time.timeSinceLevelLoad));
        }
    }

    public string getClockText() 
    {
        return clockText.text;
    }

    public void showClock(bool showClock)
    {
        clockText.enabled = showClock;
    }

    void stopClock()
    {
        stopped = true;
    }

}