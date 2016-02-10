using UnityEngine;
using System.Collections;

public class ItemsPickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PickableItem")
            col.gameObject.GetComponent<PickableItem>().pickup();
    }
}
