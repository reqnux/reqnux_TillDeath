using UnityEngine;
using System.Collections;

public class AdrenalineRushAbility : SpecialAbility {

	[SerializeField][Range(0,1)] float speedPercentageGained;
	[SerializeField] float duration;
	bool abilityActive;

	public override void onDamageTaken() {
		if(!abilityActive)
			StartCoroutine (inreaseSpeed());
	}

	IEnumerator inreaseSpeed() {
		abilityActive = true;
		float speedInrease = (player.Stats.BaseMovementSpeed + player.Stats.StatPointsMovementSpeed) * speedPercentageGained;
		player.Stats.BonusMovementSpeed += speedInrease;
		yield return new WaitForSeconds (duration);
		player.Stats.BonusMovementSpeed -= speedInrease;
		abilityActive = false;
	}
}
