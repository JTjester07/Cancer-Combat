using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    public static int Health = 100;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 25;
            Destroy(collision.gameObject);

            // Perform other actions or reactions to the collision here

            if (Health <= 0)
            {
                // Player defeated, handle the game over logic
                SceneManager.LoadScene(5);
            }
        }
    }
}