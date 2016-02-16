using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveBonusRow : MonoBehaviour {

    Bonus bonus;
    bool initialized;

    void Update()
    {
        if (initialized && (bonus == null ||bonus.TimeLeft <= 0 ))
            Destroy(gameObject);
    }

    public void init(Bonus activeBonus)
    {
        bonus = activeBonus;
        transform.GetComponentInChildren<BonusTimeLeftBar>().Bonus = bonus;

        Sprite bonusIcon = bonus.transform.FindChild("bonusIcon").GetComponent<SpriteRenderer>().sprite;
        transform.FindChild("bonusIcon").GetComponent<Image>().sprite = bonusIcon;

        initialized = true;
    }
}
