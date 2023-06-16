using UnityEngine;

public class enemyChase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;

    void Update()
    {
        // Calculate the direction from enemy to player
        Vector3 direction = player.position - transform.position;

        // Normalize the direction vector to get a unit direction
        direction.Normalize();

        // Move the enemy towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}