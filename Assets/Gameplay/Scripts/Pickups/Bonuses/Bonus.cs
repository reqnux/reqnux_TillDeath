using UnityEngine;
using System.Collections;

public abstract class Bonus : PickableItem {

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
        
    public abstract void activate();

    public float Duration
    {
        get { return duration;}
    }
    public float TimeLeft
    {
        get { return timeLeft;}
        set { timeLeft = value;}
    }

}
