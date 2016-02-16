using UnityEngine;
using System.Collections;

public abstract class Bonus : PickableItem {

    protected Player player;

    [SerializeField] protected float duration;
    [SerializeField] protected float timeLeft;

    float tickRate = 0.2f; //in seconds
    float lastTickTime;
    bool activated;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindObjectOfType<Player>();
    }

    public override void pickup()
    {
        base.pickup();
    }

    void Update()
    {
        if (activated && duration > 0)
        {
            if (Time.timeSinceLevelLoad > lastTickTime + tickRate)
            {
                timeLeft -= tickRate;
                lastTickTime = Time.timeSinceLevelLoad;
            }
        }
    }

    public virtual void activate()
    {
        activated = true;
    }

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
