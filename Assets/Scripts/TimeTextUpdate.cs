using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeTextUpdate : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Start()
    {
        timeText.text = "Cancer Lifespan: " + TimeTracker.gameTime.ToString();
    }
}
