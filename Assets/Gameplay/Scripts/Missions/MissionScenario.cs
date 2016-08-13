using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionScenario : MonoBehaviour {

	[SerializeField] List<MissionScenarioEvent> scenarioEvents;
	MissionSpawner spawner;

	void Awake() {
		spawner = GameObject.FindObjectOfType<MissionSpawner> ();
		foreach (MissionScenarioEvent e in scenarioEvents) {
			e.Spawner = spawner;
		}
	}

	void Update() {
		foreach (MissionScenarioEvent e in scenarioEvents) {
			if (e.isActive()) {
				
			}
		}
	}
}
