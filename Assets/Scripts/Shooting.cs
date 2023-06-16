using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject trackerPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float spawnOffset = 0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FireTracker();
        }
    }

    void FireBullet()
    {
        Vector3 spawnPosition = bulletSpawnPoint.position + (bulletSpawnPoint.up * spawnOffset);
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletSpawnPoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    void FireTracker()
    {
        Vector3 spawnPosition = bulletSpawnPoint.position + (bulletSpawnPoint.up * spawnOffset);
        GameObject bullet = Instantiate(trackerPrefab, spawnPosition, bulletSpawnPoint.rotation);

        // Find the nearest game object with the "Tumor" tag
        GameObject nearestTumor = FindNearestTumor();
        if (nearestTumor != null)
        {
            // Calculate the direction from bullet to the nearest tumor
            Vector3 direction = nearestTumor.transform.position - bullet.transform.position;
            direction.Normalize();

            // Apply velocity to the bullet in the direction of the nearest tumor
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * bulletSpeed;
        }
        else
        {
            // Fallback behavior if no tumor is found
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }

    GameObject FindNearestTumor()
    {
        GameObject[] tumors = GameObject.FindGameObjectsWithTag("Tumor");
        GameObject nearestTumor = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject tumor in tumors)
        {
            float distance = Vector3.Distance(transform.position, tumor.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTumor = tumor;
            }
        }

        return nearestTumor;
    }
}