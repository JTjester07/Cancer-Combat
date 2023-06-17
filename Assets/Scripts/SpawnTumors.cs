using UnityEngine;

public class SpawnTumors : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnAreaSize = new Vector2(5f, 5f);
    public int numberOfPrefabs = 5;
    public GameObject upgradeCanvas;

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            GameObject prefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            GetHit prefabScript = prefab.GetComponent<GetHit>();
            spawnTumor prefabScriptTwo = prefab.GetComponent<spawnTumor>();
            prefabScript.upgradeCanvas = upgradeCanvas;
            prefabScriptTwo.upgradeCanvas = upgradeCanvas;
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        Vector2 centerPosition = transform.position;
        float randomX = Random.Range(centerPosition.x - spawnAreaSize.x / 2, centerPosition.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(centerPosition.y - spawnAreaSize.y / 2, centerPosition.y + spawnAreaSize.y / 2);
        return new Vector2(randomX, randomY);
    }
}