using UnityEngine;
using System.Collections;

public abstract class StateBar : MonoBehaviour {

    protected void updateBar(float currentValue, float maxValue) {
        if (maxValue > 0)
            transform.localScale = new Vector2((currentValue / maxValue), transform.localScale.y);
        else
            Debug.LogError("StateBar : maxValue <= 0");
    }
}
