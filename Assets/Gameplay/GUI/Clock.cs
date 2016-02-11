using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clock : MonoBehaviour {

    [SerializeField]
    private  bool isVisible = true;
    private Text clockText;
    private float lastUpdateTime = 0;
    private int minutes;
    private int seconds;
    private float modulo;


    void Awake() 
    {
        clockText = GetComponent<Text>();
    }

    void Update () 
    {
        if (Time.time > lastUpdateTime + 1) 
        {
            lastUpdateTime = Time.time;
            modulo = Time.time % 60;
            minutes = Mathf.FloorToInt(Time.time/60);
            seconds = Mathf.FloorToInt (modulo);
            if (isVisible)
                clockText.text = getClockText();
            else
                clockText.text = "";
        }
    }

    private string getClockText() 
    {
        string min = minutes.ToString();
        string sec = seconds.ToString();
        if (minutes.ToString().Length == 1) 
            min = "0" + min;
        if (seconds.ToString().Length == 1) 
            sec = "0" + sec;
        return min+":"+sec;
    }

    public void showClock(bool showClock)
    {
        isVisible = showClock;
    }

}