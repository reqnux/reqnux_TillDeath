using UnityEngine;
using System.Collections.Generic;

public class BonusManager : MonoBehaviour {

	Player player;
    List<Bonus> activeBonuses;
    ActiveBonusesPanel bonusesPanel;

    List<Bonus> bonusestoRemove;

    void Awake () {
		player = GetComponent<Player> ();
        activeBonuses = new List<Bonus>();
        bonusestoRemove = new List<Bonus>();
	}
    void Start () {
        bonusesPanel = GameObject.FindObjectOfType<ActiveBonusesPanel>();
    }

    void Update()
    {
        for(int i = activeBonuses.Count - 1; i >= 0; i--)
        {
            if (activeBonuses[i].TimeLeft <= 0)
            {
                activeBonuses[i].deactivate();
                Destroy(activeBonuses[i].gameObject);
                activeBonuses.RemoveAt(i);
            }
        }
    }
	
    public void handleBonus(Bonus bonus)
    {
        Bonus activeBonus = findActiveBonusOfType(bonus);
        if (activeBonus)
        {
			activeBonus.TimeLeft += bonus.Duration + bonus.Duration * player.Stats.IncreasedBonusDuration;
            bonus.destroy();
        }
        else
        {
            activeBonuses.Add(bonus);
            bonusesPanel.addBonus(bonus);
			bonus.TimeLeft = bonus.Duration + bonus.Duration * player.Stats.IncreasedBonusDuration;
            bonus.activate();
        }
    }
    Bonus findActiveBonusOfType(Bonus bonus)
    {
        foreach (Bonus b in activeBonuses)
        {
            if (b.GetType() == bonus.GetType())
                return b;
        }
        return null;
    }

}
