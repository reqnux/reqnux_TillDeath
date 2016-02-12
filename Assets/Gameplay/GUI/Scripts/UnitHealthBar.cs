using UnityEngine;
using System.Collections;

public class UnitHealthBar : StateBar {

    [SerializeField]
    private Unit unit;
    private UnitStats unitStats;

    void Start()
    {
        unitStats = unit.Stats;
    }

	void Update () 
    {
        updateBar(unitStats.CurrentHealth, unitStats.MaxHealth);
	}
}
