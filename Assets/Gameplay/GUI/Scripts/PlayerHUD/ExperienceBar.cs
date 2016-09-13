using UnityEngine;
using System.Collections;

public class ExperienceBar : StateBar {

	[SerializeField] Player player;
	UnitStats stats;

	void Start()
	{
		stats = player.Stats;
	}

	void Update () 
	{
		updateBar(stats.Experience - (player.Level-1) * Player.ExperiencePerLevel, Player.ExperiencePerLevel);
	}
}
