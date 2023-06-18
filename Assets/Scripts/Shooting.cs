using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject trackerPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float spawnOffset = 0.5f;
    public static int damageUpgrade = 1;
    public AudioClip soundEffect; // The sound effect clip to play
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect()
    {
        // Play the sound effect
        audioSource.PlayOneShot(soundEffect);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale != 0)
        {
            FireBullet();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.timeScale != 0)
        {
            FireTracker();
        }
    }

    void FireBullet()
    {
        PlaySoundEffect();
        Vector3 spawnPosition = bulletSpawnPoint.position + (bulletSpawnPoint.up * spawnOffset);
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletSpawnPoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    void FireTracker()
    {
        PlaySoundEffect();
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
            SpriteRenderer spriteRenderer = tumor.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteRenderer.enabled)
            {
                float distance = Vector3.Distance(transform.position, tumor.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestTumor = tumor;
                }
            }
        }

        return nearestTumor;
    }
}