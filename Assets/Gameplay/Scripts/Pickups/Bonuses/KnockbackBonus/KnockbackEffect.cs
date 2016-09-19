using UnityEngine;
using System.Collections;

public class KnockbackEffect : MonoBehaviour {

    [SerializeField] float range;
    [SerializeField] float knockbackForce;

    public void Start()
    {
        Destroy(gameObject,transform.GetComponentInChildren<ParticleSystem>().duration);
    }

    void FixedUpdate()
    {
        knockback();
    }
    void knockback()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);
        int i = 0;
        while (i < enemiesInRange.Length)
        {
			if (enemiesInRange[i] != null && enemiesInRange[i].tag == "Enemy" && enemiesInRange[i].GetComponent<UnitMovement>() != null)
            {
                Vector2 force = (enemiesInRange[i].transform.position - transform.position) * knockbackForce;
                enemiesInRange[i].GetComponent<UnitMovement>().disableMovement();
                enemiesInRange[i].GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Force);
                enemiesInRange[i].GetComponent<UnitMovement>().enableMovement();
            }
            i++;
        }
    }

}
