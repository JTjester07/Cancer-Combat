using UnityEngine;

public class spawnTumor : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnAreaSize = new Vector2(5f, 5f);
    public float spawnInterval = 120f; // 2 minutes
    public GameObject upgradeCanvas;

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPrefab();
            timer = spawnInterval;
        }
    }

    void SpawnPrefab()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject prefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        GetHit prefabScript = prefab.GetComponent<GetHit>();
        spawnTumor prefabScriptTwo = prefab.GetComponent<spawnTumor>();
        prefabScript.upgradeCanvas = upgradeCanvas;
        prefabScriptTwo.upgradeCanvas = upgradeCanvas;
    }

    Vector2 GetRandomSpawnPosition()
    {
        Vector2 parentPosition = transform.position;
        float randomX = Random.Range(parentPosition.x - spawnAreaSize.x / 2, parentPosition.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(parentPosition.y - spawnAreaSize.y / 2, parentPosition.y + spawnAreaSize.y / 2);
        return new Vector2(randomX, randomY);
    }
}
