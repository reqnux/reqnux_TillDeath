using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class FinalMissionEndingSequence : MonoBehaviour {

	bool sequenceStarted;

	[Header("HUD")]
	[SerializeField][Range(0,1)] float hudFadeValue = 0.05f;
	[SerializeField] float hudFadeInterval = 0.1f;
	[SerializeField] List<Image> hudSprites;

	[Header("Enemies")]
	[SerializeField] int enemiesWaveIntervalPerWave = 8;
	[SerializeField] float enemiesWaveInterval = 2f;

	void Awake() {
		SceneFade.blackScreenFadeCompletedEvent += startCreditsScene;
	}

	public void play()	{
		sequenceStarted = true;
		//---- start final sequence ----
		// disable player panel

		// hide hud
		// tunr off buffs
		StartCoroutine(hideHud());
		// play music

		// spawn monsters
		StartCoroutine (spawnMonsters ());

		// wait for players death
		// stop game
		// fade screen
		// credits scene

	}

	IEnumerator hideHud() {
		Image[] bonusRowsImages = GameObject.FindObjectOfType<ActiveBonusesPanel>().GetComponentsInChildren<Image>();
		hudSprites.AddRange (bonusRowsImages);

		GameObject.FindObjectOfType<LevelUpIndicator> ().GetComponent<Animator> ().enabled = false;
		Text lvlUpText = GameObject.FindObjectOfType<LevelUpIndicator>().GetComponentInChildren<Text> ();
		Text clockText = GameObject.FindObjectOfType<Clock>().GetComponent<Text> ();
		Text ammoText = GameObject.FindObjectOfType<AmmoDisplay>().GetComponent<Text> ();

		while (hudSprites [0].color.a > 0) {
			foreach (Image im in hudSprites)
				im.color = new Color(im.color.r,im.color.g,im.color.b,im.color.a - hudFadeValue);
			lvlUpText.color = new Color (lvlUpText.color.r, lvlUpText.color.g, lvlUpText.color.b, lvlUpText.color.a - hudFadeValue);
			clockText.color = new Color (clockText.color.r, clockText.color.g, clockText.color.b, clockText.color.a - hudFadeValue);
			ammoText.color = new Color (ammoText.color.r, ammoText.color.g, ammoText.color.b, ammoText.color.a - hudFadeValue);
			yield return new WaitForSeconds (hudFadeInterval);
		}
		GameManager.Player.GetComponent<BonusManager> ().timeOutBonuses ();
	}

	IEnumerator spawnMonsters() {
		MissionSpawner spawner = GameObject.FindObjectOfType<MissionSpawner> ();
		spawner.spawnEnemy (EnemyType.HUGE_ZOMBIE, SpawnSide.TOP);
		spawner.spawnEnemy (EnemyType.HUGE_ZOMBIE, SpawnSide.BOT);
		spawner.spawnEnemy (EnemyType.HUGE_ZOMBIE, SpawnSide.LEFT);
		spawner.spawnEnemy (EnemyType.HUGE_ZOMBIE, SpawnSide.RIGHT);

		while (GameManager.Player.isAlive ()) {
			spawner.spawnEnemies (EnemyType.FAST_ZOMBIE, enemiesWaveIntervalPerWave,SpawnSide.TOP);
			spawner.spawnEnemies (EnemyType.FAST_ZOMBIE, enemiesWaveIntervalPerWave, SpawnSide.BOT);
			spawner.spawnEnemies (EnemyType.FAST_ZOMBIE, enemiesWaveIntervalPerWave, SpawnSide.LEFT);
			spawner.spawnEnemies (EnemyType.FAST_ZOMBIE, enemiesWaveIntervalPerWave, SpawnSide.RIGHT);
			yield return new WaitForSeconds (enemiesWaveInterval);
		}
	}

	void startCreditsScene() {
		SceneManager.LoadScene ("Credits");
	}

	void OnDisable() {
		SceneFade.blackScreenFadeCompletedEvent -= startCreditsScene;
	}

	public bool SequenceStarted {
		get{ return sequenceStarted;}
	}
}
