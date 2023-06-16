using UnityEngine;

public class enemyChase : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Find the player object using the unique tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            // Calculate the direction from enemy to player
            Vector3 direction = playerObject.transform.position - transform.position;

            // Normalize the direction vector to get a unit direction
            direction.Normalize();

            // Move the enemy towards the player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}