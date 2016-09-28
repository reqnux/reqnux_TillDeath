using UnityEngine;
using System.Collections;

public class RandomizeLookAndStats : MonoBehaviour {

	[Header ("Stats")]
	[SerializeField][Range(0,1)] float healthPercenage;
	[SerializeField][Range(0,1)] float speedPercenage;

	[Header ("Look")]
	[SerializeField][Range(0,1)] float sizePercenage;
	[SerializeField][Range(0,1)] float colorPercentage;

	Enemy enemy;
	int defaultHealth;
	float defaultSpeed;
	Color defaultColor;

	void Awake() {
		enemy = GetComponent<Enemy> ();
		defaultHealth = enemy.Stats.BaseMaxHealth;
		defaultSpeed = enemy.Stats.BaseMovementSpeed;
		defaultColor = transform.GetComponentInChildren<SpriteRenderer> ().color;
	}

	void OnEnable() {
		randomizeStats ();	
		randomizeLook ();
	}

	void randomizeStats () {
		if (healthPercenage != 0) {
			int randomHealth = (int)(defaultHealth * Random.Range (0, healthPercenage));
			enemy.Stats.BaseMaxHealth += randomHealth;
			enemy.Stats.CurrentHealth = enemy.Stats.MaxHealth;
		}
		if (speedPercenage != 0) {
			float randomSpeed = defaultHealth * Random.Range (-speedPercenage, speedPercenage);
			enemy.Stats.BaseMovementSpeed += randomSpeed;
		}
	}
	void randomizeLook () {
		if (sizePercenage != 0) {
			float randomSize = transform.localScale.x * Random.Range (-sizePercenage, sizePercenage*2);
			transform.localScale += new Vector3(randomSize,randomSize);
		}
		if (colorPercentage != 0) {
			float randomRGB = Random.Range (-colorPercentage, colorPercentage);
			Color randomColor = new Color (defaultColor.r + randomRGB, defaultColor.g + randomRGB, defaultColor.b + randomRGB);
			transform.GetComponentInChildren<SpriteRenderer> ().color = randomColor;
		}
	}

	void reset() {
		enemy.Stats.BaseMaxHealth = defaultHealth;
		enemy.Stats.BaseMovementSpeed = defaultSpeed;
		transform.GetComponentInChildren<SpriteRenderer> ().color = defaultColor;
		transform.localScale = new Vector3 (1, 1, 1);
	}

	void OnDisable() {
		reset ();
	}
}

