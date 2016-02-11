using UnityEngine;
using System.Collections;

public class ItemsPickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PickableItem")
        {
            PickableItem item = col.gameObject.GetComponent<PickableItem>();
            handleItem(item);
            item.pickup();
        }
    }

    void handleItem(PickableItem item)
    {
        if (item.GetComponent<Weapon>())
        {
            GetComponent<Player>().useWeapon(item.GetComponent<Weapon>());
        }
        else
        {
            Debug.LogError("ItemsPickup : Unrecognized PickableItem!");
        }
    }
}
