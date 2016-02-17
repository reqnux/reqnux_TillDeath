using UnityEngine;
using System.Collections;

public class BonusTimeLeftBar : StateBar {

    Bonus bonus;

    void Update () 
    {
        if (bonus)
        {
            updateBar(bonus.TimeLeft, bonus.Duration);
        }
    }

    public Bonus Bonus
    {
        set{bonus = value; }
    }
}
