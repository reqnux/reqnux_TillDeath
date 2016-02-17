using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PickableItem : MonoBehaviour {

    float removeFromMapDistance;
    float selfDestroyTime = 20; 
    float fadeAwayTime = 2;

    protected virtual void Start()
    {
        removeFromMapDistance = GameObject.FindObjectOfType<Map>().YMovementRange * 2;
        //Invoke("selfDestroy", selfDestroyTime - fadeAwayTime);
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


    void selfDestroy()
    {
        fadeAway();
        destroy();
    }

    void fadeAway()
    {
        SpriteRenderer[] sprites = transform.GetComponentsInChildren<SpriteRenderer>();
        bool spritesTransparent = false;
        float alphaChange = 0.1f;
        while (!spritesTransparent)
        {
            spritesTransparent = true;
            foreach (SpriteRenderer s in sprites)
            {
                s.color = new Color(s.color.r,s.color.g,s.color.b,s.color.a - alphaChange);
                if (s.color.a > 0)
                    spritesTransparent = false;
            }
            StartCoroutine(wait(fadeAwayTime * alphaChange));
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
