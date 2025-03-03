using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGlassPlatform : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 2.5f; // Time before breaking
    [SerializeField] private float blinkInterval = 0.1f; // Blink speed

    private SpriteRenderer spriteRenderer;
    private Collider2D platformCollider;
    private bool isBreaking = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player or a box touches the platform
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")) && !isBreaking)
        {
            StartCoroutine(BlinkAndBreak());
        }
    }

    IEnumerator BlinkAndBreak()
    {
        isBreaking = true;
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Toggle visibility
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // Fully disappear
        Destroy(gameObject);
    }
}