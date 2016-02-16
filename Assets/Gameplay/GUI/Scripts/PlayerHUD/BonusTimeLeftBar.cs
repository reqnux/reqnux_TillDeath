using UnityEngine;
using System.Collections;

public class BonusTimeLeftBar : StateBar {

    Bonus bonus;

    void Update () 
    {
        if (bonus)
        {
            Debug.Log("time lft " + bonus.TimeLeft);
            updateBar(bonus.TimeLeft, bonus.Duration);
        }
    }

    public Bonus Bonus
    {
        set{bonus = value; }
    }
}
