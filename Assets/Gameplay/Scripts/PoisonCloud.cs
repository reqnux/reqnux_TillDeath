using UnityEngine;
using System.Collections;

public class PoisonCloud : MonoBehaviour {

	[SerializeField] float duration = 7;
	[SerializeField] int damagePerTick = 1;
	[SerializeField] float timeBetweenTicks = 0.5f;
	float lastTickTime;

	void Start () {
		Invoke ("playDisappearAnimation", duration);
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			dealDamage (col.GetComponent<Player> ());
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Player") {
			dealDamage (col.GetComponent<Player> ());
		}
	}

	void dealDamage(Player player) {
		if (Time.timeSinceLevelLoad > lastTickTime + timeBetweenTicks) {
			player.takeDamage (damagePerTick);
			lastTickTime = Time.timeSinceLevelLoad;
		}
	}

	void playDisappearAnimation() {
		GetComponent<Animator> ().Play ("poisonCloudDisappear");
	}

	// called by animation
	void destroy() {
		Destroy (gameObject);
	}
}
