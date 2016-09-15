using UnityEngine;
using System.Collections;

public class ExperienceBar : StateBar {

	Player player;
	UnitStats stats;

	void Start()
	{
		player = GameManager.Player;
		stats = player.Stats;
	}

	void Update () 
	{
		updateBar(stats.Experience - (player.Level-1) * Player.ExperiencePerLevel, Player.ExperiencePerLevel);
	}
}
