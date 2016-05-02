using UnityEngine;
using System.Collections;

public class KnockbackBonus : Bonus {

    [SerializeField] KnockbackEffect effectPrefab;

    [SerializeField] int totalKnockbacks = 5;
    [SerializeField] float timeBetweenKnockbacks = 1.5f;

    float lastKnockbackTime;

    protected override void Start()
    {
        base.Start();
        duration = totalKnockbacks * timeBetweenKnockbacks;
        timeLeft = duration;
    }

    protected override void Update()
    {
        base.Update();

        if (activated && Time.timeSinceLevelLoad > lastKnockbackTime + timeBetweenKnockbacks)
        {
            lastKnockbackTime = Time.timeSinceLevelLoad;
            KnockbackEffect effect = (KnockbackEffect)Instantiate(effectPrefab, player.transform.position, player.transform.rotation);
        }
    }

}
