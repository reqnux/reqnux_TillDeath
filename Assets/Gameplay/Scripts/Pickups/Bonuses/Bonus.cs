using UnityEngine;
using System.Collections;

public class Bonus : PickableItem {

    protected Player player;

    [SerializeField] protected float duration;
    [SerializeField] protected float timeLeft;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindObjectOfType<Player>();
    }

    public override void pickup()
    {
        base.pickup();
    }
		
}
