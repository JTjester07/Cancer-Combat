using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeTextUpdate : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Start()
    {
        float roundedTime = Mathf.Round(TimeTracker.currentTime * 100f) / 100f;
        timeText.text = "Cancer Lifespan: " + roundedTime.ToString() + " Seconds";
    }
}
