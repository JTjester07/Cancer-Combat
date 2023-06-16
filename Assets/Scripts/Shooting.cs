using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float spawnOffset = 0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        Vector3 spawnPosition = bulletSpawnPoint.position + (bulletSpawnPoint.up * spawnOffset);
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletSpawnPoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bulletSpawnPoint.up * bulletSpeed;
    }
}