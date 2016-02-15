using UnityEngine;
using System.Collections.Generic;

public class BonusManager : MonoBehaviour {

    List<Bonus> activeBonuses;

    void Awake () {
        activeBonuses = new List<Bonus>();
	}
	
    public void handleBonus(Bonus bonus)
    {
        Bonus activeBonus = findActiveBonusOfType(bonus);
        if (activeBonus)
        {
            activeBonus.TimeLeft += bonus.Duration;
            bonus.destroy();
        }
        else
        {
            activeBonuses.Add(bonus);
            bonus.activate();
        }
    }
    Bonus findActiveBonusOfType(Bonus bonus)
    {
        foreach (Bonus b in activeBonuses)
        {
            if (b.GetType() == bonus.GetType())
            {
                return b;
            }

        }
        return null;
    }

}
