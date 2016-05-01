using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElectricityEffect : MonoBehaviour {

    bool initialized;
    float defaultLength;
    Vector3 defaultDirection;

    Transform source; //moveable start position
    Transform target; //moveable end position
    Vector3 startPosition; //stationary start position
    Vector3 endPosition; //stationary start position

    float effectCreatedTime;
    float effectDurationWhenNoTarget = 0.1f;
    float effectDuration = 0.5f;

    SpriteRenderer spriteRenderer;
    float lastImageFlipTime;
    float timeBetweenImageFlip = 0.1f;
	
	void Awake () {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        defaultDirection = transform.up;
        endPosition = startPosition + defaultLength * defaultDirection;
        effectCreatedTime = Time.timeSinceLevelLoad;
        Destroy(gameObject, effectDuration);
	}

    public void initEffect(Transform target)
    {
        this.target = target;
        endPosition = target.position;
        initialized = true;
    }
    public void initEffect(Transform source, Transform target)
    {
        this.source = source;
        this.target = target;
        startPosition = source.position;
        endPosition = target.position;
        initialized = true;
    }
	
	
	void Update () {

        if (target != null && source != null)
        {
            startPosition = source.position;
            endPosition = target.position;
        }
        else if (target != null)
        {
            if (!initialized && Time.timeSinceLevelLoad > effectCreatedTime + effectDurationWhenNoTarget)
                Destroy(gameObject);
            startPosition = transform.position;
            endPosition = target.position;

        }
        else if (source != null)
        {
            startPosition = source.position;
        }
        else if (target == null && source == null && !initialized)
        {
            if (Time.timeSinceLevelLoad > effectCreatedTime + effectDurationWhenNoTarget)
                Destroy(gameObject);
            startPosition = transform.position;
            endPosition = startPosition + defaultLength * defaultDirection;
        }

        transform.position = startPosition;
        lookAtTarget(endPosition);
        transform.localScale = new Vector3(transform.localScale.x, Vector3.Magnitude(endPosition- startPosition),1);

        flipImage();
	}

    void lookAtTarget(Vector3 targetLocation) {
        Vector3 diff =  targetLocation - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    void flipImage()
    {
        if (Time.timeSinceLevelLoad > lastImageFlipTime + timeBetweenImageFlip)
        {
            spriteRenderer.flipY = !spriteRenderer.flipY;
            lastImageFlipTime = Time.timeSinceLevelLoad;
        }
    }


    public float DefaultLength
    {
        set{defaultLength = value;}
    }
}
