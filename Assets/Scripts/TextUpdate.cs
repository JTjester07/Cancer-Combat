using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    public TextMeshProUGUI killedText;

    // Update is called once per frame
    void Start()
    {
        killedText.text = "Tumors Defeated: " + TumorTracker.tumorsKilled.ToString();
    }
}
