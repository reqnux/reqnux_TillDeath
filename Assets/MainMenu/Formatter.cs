using System.Collections;
using UnityEngine;

public static class Formatter {

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
        string min = Mathf.FloorToInt(seconds / 60).ToString();
        string sec = (seconds%60).ToString();
        if (min.Length == 1) 
            min = "0" + min;
        if (sec.Length == 1) 
            sec = "0" + sec;
        return min + ":" + sec; 
    }

    public static int sceneNameToMissionNumber(string sceneName)
    {
        int missionNumber;
        if(int.TryParse(sceneName.Substring(7, sceneName.Length - 7), out missionNumber))
            return missionNumber;
        Debug.LogError("Formatter : sceneNameToMissionNumber parsing error!");
        return -1;
    }

	public static bool intToBool(int intBool) 
	{
		return intBool == 1;
	}
	public static int boolToInt(bool b) 
	{
		return b ? 1 : 0;
	}
}
