using UnityEngine;
using System.Collections;

public class ItemsDrop : MonoBehaviour {

    [SerializeField] int itemDropChance; // in %
    [SerializeField] PickableItem[] items;

    void Start () {
	
	}
	
    public void dropRandomItem()
    {
        if(Random.Range(1,100) <= itemDropChance)
            Instantiate(items[Random.Range(0, items.Length)], transform.position, Quaternion.identity);
    }
}
