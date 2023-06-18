using UnityEngine;

public class PulsatingObject : MonoBehaviour
{
    public float pulseDuration = 1.0f; // Duration of one pulse cycle in seconds
    public AnimationCurve pulseCurve; // Animation curve to control the pulsation behavior

    private Vector3 initialScale;
    private Color initialColor;
    private float timer;

    private void Start()
    {
        // Record the initial scale and color of the object
        initialScale = transform.localScale;
        initialColor = GetComponent<Renderer>().material.color;
    }

    private void Update()
    {
        // Update the timer based on the elapsed time
        timer += Time.deltaTime;

        // Calculate the current scale and color based on the pulse animation curve
        float t = timer / pulseDuration;
        float scale = initialScale.x * pulseCurve.Evaluate(t);
        Color color = new Color(initialColor.r, initialColor.g, initialColor.b, pulseCurve.Evaluate(t));

        // Apply the new scale and color to the object
        transform.localScale = new Vector3(scale, scale, scale);
        GetComponent<Renderer>().material.color = color;

        // Reset the timer when one pulse cycle is completed
        if (timer >= pulseDuration)
        {
            timer = 0f;
        }
    }
}
