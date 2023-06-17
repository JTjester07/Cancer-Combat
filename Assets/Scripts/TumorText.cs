using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TumorText : MonoBehaviour
{
    public TextMeshProUGUI killedText;

    // Update is called once per frame
    void Start()
    {
        killedText.text = "You have defeated " + TumorTracker.totalTumorsKilled.ToString() + " tumors so far!";
    }
}
