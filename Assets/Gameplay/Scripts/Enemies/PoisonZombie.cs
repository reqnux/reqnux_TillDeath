using UnityEngine;
using System.Collections;

public class PoisonZombie : Enemy {

	[SerializeField] PoisonCloud poisonCloudPrefab;

	public override void Awake () 
	{
		base.Awake();
		type = EnemyType.POISON_ZOMBIE;
	}

	public override void death() 
	{
		Instantiate (poisonCloudPrefab,transform.position,Quaternion.identity);

		deathEvent();
		gameObject.SetActive (false);
		reset ();
	}
}
