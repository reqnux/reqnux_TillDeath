using UnityEngine;
using System.Collections;

public class AdrenalineRushAbility : SpecialAbility {

	[SerializeField][Range(0,1)] float speedPercentageGained;
	[SerializeField] float duration;

	public override void onDamageTaken() {
		StartCoroutine (inreaseSpeed());
	}

	IEnumerator inreaseSpeed() {
		player.Stats.BonusMovementSpeed += player.Stats.BonusMovementSpeed*speedPercentageGained;
		yield return new WaitForSeconds (duration);
		player.Stats.BonusMovementSpeed -= player.Stats.BonusMovementSpeed*speedPercentageGained;
	}
}
