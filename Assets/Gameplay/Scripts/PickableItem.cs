using UnityEngine;
using System.Collections;

public abstract class PickableItem : MonoBehaviour {

    public abstract void pickup();
    protected void removeFromMap()
    {
        Destroy(gameObject);
    }
}
