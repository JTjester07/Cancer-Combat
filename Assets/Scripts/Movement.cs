using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animation animation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from arrow keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Face the player's sprite towards the mouse cursor
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // distance from camera
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.up = (targetPos - transform.position).normalized;
    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}