using UnityEngine;
using System.Collections;

public class LonelyReloaderAbility : SpecialAbility {

	[SerializeField] KnockbackEffect knockbackPrefab;

	public override void init () {
		base.init ();
	}

	public override void onReload() {
		Instantiate (knockbackPrefab, player.transform.position, Quaternion.identity);
	}
}
