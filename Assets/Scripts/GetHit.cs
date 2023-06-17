using UnityEngine;

public class GetHit : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnAreaSize = new Vector2(5f, 5f);
    private int health = 30;
    public GameObject upgradeCanvas;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= Shooting.damageUpgrade;

            if (health <= 0)
            {
                Destroy(gameObject);
                TumorTracker.tumorsKilled += 1;
                TumorTracker.totalTumorsKilled += 1;

                // Starts the player upgrade process
                if (TumorTracker.objectCount > 1)
                {
                    upgradeCanvas.SetActive(true);
                    Time.timeScale = 0.1f;
                }
            }

            Destroy(collision.gameObject);
            SpawnPrefab();
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
}
