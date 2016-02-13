using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class StatsFilesManager {

    private const string dataPath = "/stats.banana";

    public static void saveSurvivalHighscores(SurvivalHsData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + dataPath);

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("saved in " + Application.persistentDataPath + dataPath);
    }

    public static SurvivalHsData loadSurvivalHighscores()
    {
        if (File.Exists(Application.persistentDataPath + dataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + dataPath, FileMode.Open);
            SurvivalHsData data = (SurvivalHsData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        Debug.LogWarning("StatsFilesManager : Can't load survival highscores! File doesn't exists!");
        SurvivalHsData emptyData = new SurvivalHsData(0);
        return emptyData;
    }
}
