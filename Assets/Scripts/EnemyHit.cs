using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private int health = 2;
    public AudioClip soundEffect; // The sound effect clip to play
    private AudioSource audioSource; // AudioSource reference

    private void Start()
    {
        // Get the AudioSource component from the parent GameObject
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= Shooting.damageUpgrade;

            if (health <= 0)
            {
                audioSource.PlayOneShot(soundEffect);
                StartCoroutine(DestroyWithDelay());
            }

            Destroy(collision.gameObject);
        }
    }

    private System.Collections.IEnumerator DestroyWithDelay()
    {
        // Disable the SpriteRenderer component
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        // Disable the Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.simulated = false;

        // Disable the CircleCollider2D component
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider != null)
            collider.enabled = false;

        // Play the sound effect
        audioSource.PlayOneShot(soundEffect);

        // Wait for the sound effect to finish playing
        yield return new WaitForSeconds(soundEffect.length);

        // Destroy the object
        Destroy(gameObject);
    }

}
