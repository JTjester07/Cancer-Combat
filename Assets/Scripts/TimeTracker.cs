using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public static float currentTime = 0f;

    private void Update()
    {
        // Update the game time based on the time elapsed since the last frame
        currentTime += Time.deltaTime;
    }
}