using UnityEngine;
using System.Collections.Generic;

public class MissionsHighscores : Highscores {

    public const int MISSIONS_COUNT = 12;

    public bool checkMissionNewTopScore(int missionNumber, int score)
    {
        Debug.Log("x");
        StatsFilesManager sfm = new StatsFilesManager();
        MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();
        if (missionNumber > MISSIONS_COUNT || missionNumber < 1)
            Debug.LogError("MissionsHighscores : Wrong missionNumber! missionNumber = " + missionNumber);

        return score > missionsHighscores.scores[missionNumber - 1];
    }

    public void setMissionTopScore(int missionNumber, int score)
    {
        StatsFilesManager sfm = new StatsFilesManager();
        MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();
        if (missionNumber > MISSIONS_COUNT || missionNumber < 1)
            Debug.LogError("MissionsHighscores : Wrong missionNumber! missionNumber = " + missionNumber);
        missionsHighscores.scores[missionNumber - 1] = score;
        sfm.saveMissionsHighscores(missionsHighscores);
    }

    public int getMissionScore(int missionNumber)
    {
        StatsFilesManager sfm = new StatsFilesManager();
        MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();
        if (missionNumber > MISSIONS_COUNT || missionNumber < 1)
            Debug.LogError("MissionsHighscores : Wrong missionNumber! missionNumber = " + missionNumber);
        
        return missionsHighscores.scores[missionNumber - 1];
    }
}

[System.Serializable]
public class MissionsHsData
{
    public int[] scores;

    public MissionsHsData() {}   // use this constructor when reading from file
    public MissionsHsData(int x) // use this constructor for empty highscores list
    {
        scores = new int[MissionsHighscores.MISSIONS_COUNT];
    } 
}