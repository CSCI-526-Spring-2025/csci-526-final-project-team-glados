using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float damage = collision.GetComponent<PlayerController>().GetCurrentVelocityMagnitude();
            transform.parent.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (collision.CompareTag("Hostility"))
        {
            float damage = collision.GetComponent<Rigidbody2D>().velocity.magnitude;
            transform.parent.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (collision.CompareTag("Box")) {
            Enemy enemy = transform.parent.GetComponent<Enemy>();
            if (enemy is RedEnemy) {
                Debug.Log("RedEnemy hit on head by box! Instantly kill");
                enemy.TakeDamage(9999f);
            }
            else {
                float damage = collision.GetComponent<Rigidbody2D>().velocity.magnitude;
                enemy.TakeDamage(damage);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
