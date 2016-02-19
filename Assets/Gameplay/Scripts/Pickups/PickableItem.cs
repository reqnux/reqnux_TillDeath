using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PickableItem : MonoBehaviour {

    float removeFromMapDistance;
    float selfDestroyTime = 20; 
    float fadeAwayTime = 4;

    protected virtual void Start()
    {
        removeFromMapDistance = GameObject.FindObjectOfType<Map>().YMovementRange * 2;
        if (gameObject.name != "DefaultWeapon")
            Invoke("selfDestroy", selfDestroyTime - fadeAwayTime);
    }

    public virtual void pickup()
    {
        removeFromMap();
        CancelInvoke("selfDestroy");
        StopCoroutine("fadeAway");
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
        StartCoroutine("fadeAway");
    }

    IEnumerator fadeAway()
    {
        SpriteRenderer[] sprites = transform.GetComponentsInChildren<SpriteRenderer>();
        bool spritesTransparent = false;
        float alphaChange = 0.05f;
        while (!spritesTransparent)
        {
            spritesTransparent = true;
            foreach (SpriteRenderer s in sprites)
            {
                s.color = new Color(s.color.r,s.color.g,s.color.b,s.color.a - alphaChange);
                if (s.color.a > 0)
                    spritesTransparent = false;
            }
            yield return new WaitForSeconds(fadeAwayTime * alphaChange);
        }
        destroy();
    }

}
