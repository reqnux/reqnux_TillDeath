using UnityEngine;
using System.Collections;

public class PoisonCloud : MonoBehaviour {

	[SerializeField] float duration = 7;
	[SerializeField] protected int damagePerTick = 1;
	[SerializeField] protected float timeBetweenTicks = 0.5f;
	protected float lastTickTime;

	protected virtual void Start () {
		Invoke ("playDisappearAnimation", duration);
	}
	
	protected virtual void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			dealDamage (col.GetComponent<Player> ());
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Player") {
			dealDamage (col.GetComponent<Player> ());
		}
	}

	protected void dealDamage(Player player) {
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
