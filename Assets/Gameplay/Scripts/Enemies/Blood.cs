using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blood : MonoBehaviour {

    [SerializeField] Sprite[] blood;

	void Start () {
        GetComponent<SpriteRenderer>().sprite = blood[Random.Range(0, blood.Length)];
    }

}
