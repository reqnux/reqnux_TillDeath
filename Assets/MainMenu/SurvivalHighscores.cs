using UnityEngine;
using System.Collections.Generic;

public class SurvivalHighscores : Highscores {

    public const int HIGHSCORES_COUNT = 10;

    public bool checkQualifiedOnList(int score, int timeSurvived)
    {
        StatsFilesManager sfm = new StatsFilesManager();
        SurvivalHsData currentHighscores = sfm.loadSurvivalHighscores();
        if (currentHighscores.scores.Count > HIGHSCORES_COUNT)
            Debug.LogError("SurvivalHighscores : currentHighscores contains more than " + HIGHSCORES_COUNT + " records!");

        foreach(Pair p in currentHighscores.scores)
        {
            if (p.second < timeSurvived || (p.second == timeSurvived && p.first < score))
               return true;
        }

        return currentHighscores.scores.Count < HIGHSCORES_COUNT;
    }

    public void addNewHighscore(int score, int timeSurvived)
    {
        StatsFilesManager sfm = new StatsFilesManager();
        SurvivalHsData currentHighscores = sfm.loadSurvivalHighscores();

        int newScoreIndex = findNewScoreIndex(currentHighscores.scores, score, timeSurvived);
        currentHighscores.scores.Insert(newScoreIndex, new Pair(score, timeSurvived));
        if(currentHighscores.scores.Count > HIGHSCORES_COUNT)
            currentHighscores.scores.RemoveAt(currentHighscores.scores.Count - 1);

        sfm.saveSurvivalHighscores(currentHighscores);
    }


    int findNewScoreIndex(List<Pair> scores, int score, int timeSurvived)
    {
        int i = 0;
        for (;i < scores.Count; i++)
        {
            if (scores[i].second < timeSurvived || (scores[i].second == timeSurvived && scores[i].first < score))
                return i;
        }
        return i;
    }
}

[System.Serializable]
public class SurvivalHsData
{
    // pair.first - score
    // pair.second - time survived in seconds
    public List<Pair> scores;

    public SurvivalHsData() {}   // use this constructor when reading from file
    public SurvivalHsData(int x) // use this constructor for empty highscores list
    {
        scores = new List<Pair>(SurvivalHighscores.HIGHSCORES_COUNT);
    } 
}

[System.Serializable]
public class Pair
{
    public int first;
    public int second;

    public Pair(int f, int s)
    {
        first = f;
        second = s;
    }
}