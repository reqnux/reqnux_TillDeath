using System.Collections;
using UnityEngine;

public class Formatter {

    public static int clockTextToSeconds(string clockText) // 12:34 format expected
    {
        int min, sec;
        if (int.TryParse(clockText.Substring(0, 2), out min))
        {
            if (int.TryParse(clockText.Substring(3, 2), out sec))
                return min * 60 + sec;
        }
        Debug.LogError("Formatter : clockText wrong format!");
        return -1;
    }

    public static string secondsToClockText(int seconds)
    {
        return Mathf.FloorToInt(seconds/60) +":" + seconds % 60; 
    }
}
