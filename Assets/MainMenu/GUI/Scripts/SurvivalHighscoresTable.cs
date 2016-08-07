using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SurvivalHighscoresTable : MonoBehaviour {

	void OnEnable () 
    {
        loadHighscores();
	}
	
    void loadHighscores()
    {
        StatsFilesManager sfm = new StatsFilesManager();
        SurvivalHsData data = sfm.loadSurvivalHighscores();
        for (int i = 0; i < data.scores.Count; i++)
        {
            transform.GetChild(i).FindChild("score").GetComponent<Text>().text = data.scores[i].first.ToString();
            string time = Formatter.secondsToClockText(data.scores[i].second);
            transform.GetChild(i).FindChild("time").GetComponent<Text>().text = time;
        }
    }
}
