using UnityEngine;
using System.Collections;

public class UnitHealthBar : StateBar {

    [SerializeField]
    private Unit unit;
    private UnitStats unitStats;

    void Start()
    {
		unit = GameManager.Player;
        unitStats = unit.Stats;
    }

	void Update () 
    {
        updateBar(unitStats.CurrentHealth, unitStats.MaxHealth);
	}
}
