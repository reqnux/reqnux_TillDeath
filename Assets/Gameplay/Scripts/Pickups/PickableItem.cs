using UnityEngine;
using System.Collections;

public abstract class PickableItem : MonoBehaviour {

    float removeFromMapDistance;

    protected virtual void Start()
    {
        removeFromMapDistance = GameObject.FindObjectOfType<Map>().YMovementRange * 2;
    }

    public virtual void pickup()
    {
        removeFromMap();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    // removes used object from the map and hides it from camera
    // currently used object can't be destroyed, because it causes MissingReferenceException
    void removeFromMap()
    {
        transform.Translate(new Vector3(0, -removeFromMapDistance, 0));
    }
}
