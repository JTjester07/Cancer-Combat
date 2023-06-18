using UnityEngine;

public class GetHit : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnAreaSize = new Vector2(5f, 5f);
    private int health = 30;
    public GameObject upgradeCanvas;
    public AudioClip soundEffect; // The sound effect clip to play
    private bool isDestroyed = false; // Flag to prevent further interaction
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private void Start()
    {
        // Get the AudioSource component from the parent GameObject
        AudioSource audioSource = GetComponentInParent<AudioSource>();

        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestroyed)
            return; // If already destroyed, ignore collision

        if (collision.gameObject.tag == "bullet")
        {
            int num = 0;

            do
            {
                health -= 1;

                if (health <= 0)
                {
                    isDestroyed = true; // Set the flag to prevent further interaction
                    DestroyWithDelay(gameObject, soundEffect.length);
                    TumorTracker.tumorsKilled += 1;
                    TumorTracker.totalTumorsKilled += 1;

                    // Starts the player upgrade process
                    if (TumorTracker.objectCount > 1)
                    {
                        upgradeCanvas.SetActive(true);
                        Time.timeScale = 0.05f;
                    }
                }

                Destroy(collision.gameObject);
                SpawnPrefab();

                num++;
            } while (num < Shooting.damageUpgrade);
        }
        else if (collision.gameObject.tag == "tracker")
        {
            Destroy(collision.gameObject);
        }
    }

    void SpawnPrefab()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomSpawnPosition()
    {
        Vector2 parentPosition = transform.position;
        float randomX = Random.Range(parentPosition.x - spawnAreaSize.x / 2, parentPosition.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(parentPosition.y - spawnAreaSize.y / 2, parentPosition.y + spawnAreaSize.y / 2);
        return new Vector2(randomX, randomY);
    }

    void DestroyWithDelay(GameObject obj, float delay)
    {
        // Disable the SpriteRenderer component
        spriteRenderer.enabled = false;

        // Disable the 2D Rigidbody component
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.simulated = false;

        // Disable the Circle Collider component
        CircleCollider2D collider = obj.GetComponent<CircleCollider2D>();
        if (collider != null)
            collider.enabled = false;

        Destroy(obj, delay);
    }

}
