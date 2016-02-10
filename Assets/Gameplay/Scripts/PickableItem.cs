using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public void pickup()
    {
        removeFromMap();
    }


    public void removeFromMap()
    {
        Destroy(gameObject);
    }
}
