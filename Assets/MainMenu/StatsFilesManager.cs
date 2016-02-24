using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class StatsFilesManager {

    const string survivalDataPath = "/mystatsSurvival.dat";
    const string missionsDataPath = "/mystatsMissions.dat";

    public void saveSurvivalHighscores(SurvivalHsData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + survivalDataPath);
        Debug.Log("Data saved count " + data.scores.Count);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("saved in " + Application.persistentDataPath + survivalDataPath);
    }

    public SurvivalHsData loadSurvivalHighscores()
    {
        if (File.Exists(Application.persistentDataPath + survivalDataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + survivalDataPath, FileMode.Open);
            SurvivalHsData data = (SurvivalHsData)bf.Deserialize(file);
            Debug.Log("Data loaded count " + data.scores.Count);
            file.Close();
            return data;
        }
        Debug.LogWarning("StatsFilesManager : Can't load survival highscores! File doesn't exists!");
        SurvivalHsData emptyData = new SurvivalHsData(0);
        return emptyData;
    }

    public void saveMissionsHighscores(MissionsHsData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + missionsDataPath);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("saved in " + Application.persistentDataPath + missionsDataPath);
    }

    public MissionsHsData loadMissionsHighscores()
    {
        if (File.Exists(Application.persistentDataPath + missionsDataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + missionsDataPath, FileMode.Open);
            MissionsHsData data = (MissionsHsData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        Debug.LogWarning("StatsFilesManager : Can't load missions highscores! File doesn't exists!");
        MissionsHsData emptyData = new MissionsHsData(0);
        return emptyData;
    }
}
