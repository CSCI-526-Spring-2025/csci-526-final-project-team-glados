using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    // Count the number of times the player hits
    private int hitCount = 0;

    protected override void Update() {
        base.Update();
    }
    
    public override void TakeDamage(float damage) {
        // Check if damage is coming from a Box
        if (damage >= 9999f) 
        {
            Debug.Log("RedEnemy was hit by a Box! Instantly dying.");
            Die(); // Die instantly
            return; // Exit the function
        }
        // Increase the hit counter every time the player hits the enemy
        hitCount++;

        StartCoroutine(DamageFlash());

        if (hitCount >= 3) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player collided with the HeadTrigger
            HeadTrigger headTrigger = GetComponentInChildren<HeadTrigger>();

            if (headTrigger != null && collision.otherCollider == headTrigger.GetComponent<Collider2D>())
            {
                Debug.Log("Player touched RedEnemy's head - it gets hit.");
                // Do not respawn if the player lands on the head
                return; 
            }

            Debug.Log("Player touched RedEnemy's body! Respawn");
        }
    }
}
