using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

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

        // Calculate the direction from player to target
        Vector2 direction = (targetPos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation only on the Z-axis
        transform.eulerAngles = new Vector3(0f, 0f, angle - 90f); // Adjust the angle by -90 degrees

        // Alternatively, you can use LookAt to directly face the target
        // transform.LookAt(targetPos, Vector3.forward);

    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
