using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionScenario : MonoBehaviour {

	public List<MissionScenarioEvent> scenarioEvents;
	MissionSpawner spawner;
	Player player;

	void Awake() {
		// init spawners
		player = GameObject.FindObjectOfType<Player>();
		spawner = GameObject.FindObjectOfType<MissionSpawner> ();
		foreach (MissionScenarioEvent e in scenarioEvents) {
			e.init(spawner);
		}
	}

	void Update() {
		if (player.isAlive ()) {
			foreach (MissionScenarioEvent e in scenarioEvents) {
				if (e.isActive()) {
					e.execute ();
				}
			}
		}
	}
}
