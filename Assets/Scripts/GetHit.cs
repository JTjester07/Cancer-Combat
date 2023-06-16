using UnityEngine;

public class GetHit : MonoBehaviour
{
    private int health = 30;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= 1;

            if (health <= 0)
                Destroy(gameObject);

            Destroy(collision.gameObject);
        }
    }
}