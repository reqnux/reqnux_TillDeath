using UnityEngine;
using System.Collections;

public class AdrenalineRushAbility : SpecialAbility {

	[SerializeField] int speedGained;
	[SerializeField] float duration;

	public override void onDamageTaken() {
		StartCoroutine (inreaseSpeed());
	}

	IEnumerator inreaseSpeed() {
		player.Stats.BonusMovementSpeed += speedGained;
		yield return new WaitForSeconds (duration);
		player.Stats.BonusMovementSpeed -= speedGained;
	}
}
