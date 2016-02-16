using UnityEngine;
using System.Collections;

public class ActiveBonusesPanel : MonoBehaviour {

    [SerializeField] ActiveBonusRow bonusRowPrefab;

    public void addBonus(Bonus bonus)
    {
        ActiveBonusRow row = Instantiate(bonusRowPrefab);
        row.transform.SetParent(transform, false);
        row.init(bonus);
    }

}
