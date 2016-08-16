using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionScenario : MonoBehaviour {

	public List<MissionScenarioEvent> scenarioEvents;
	MissionSpawner spawner;

	void Awake() {
		// init spawners
		spawner = GameObject.FindObjectOfType<MissionSpawner> ();
		foreach (MissionScenarioEvent e in scenarioEvents) {
			e.init(spawner);
		}
	}

	void Update() {
		foreach (MissionScenarioEvent e in scenarioEvents) {
			if (e.isActive()) {
				e.execute ();
			}
		}
	}
}
