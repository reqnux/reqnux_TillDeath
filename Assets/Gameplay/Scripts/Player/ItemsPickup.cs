using UnityEngine;
using System.Collections;

public class ItemsPickup : MonoBehaviour {

    Player player;

    void Start()
    {
        player = GetComponent<Player>();   
    }

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
		if(player.ActiveAbilities.onItemPickup != null)
			player.ActiveAbilities.onItemPickup (item);
        if (item.GetComponent<Weapon>())
        {
            if (player.CurrentWeapon)
                player.CurrentWeapon.destroy();
            player.useWeapon(item.GetComponent<Weapon>());
        }
        else if(item.GetComponent<Bonus>())
        {
            if (item.GetComponent<Bonus>().Duration != 0)
                player.GetComponent<BonusManager>().handleBonus(item.GetComponent<Bonus>());
            else
                item.GetComponent<Bonus>().activate();
        }
        else 
            Debug.LogError("ItemsPickup : Unrecognized PickableItem!");
            
    }
}
