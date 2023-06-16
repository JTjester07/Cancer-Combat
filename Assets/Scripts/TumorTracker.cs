using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TumorTracker : MonoBehaviour
{
    private int objectCount;
    public TextMeshProUGUI tumorText;

    void Update()
    {
        CountObjectsWithTag();

        tumorText.text = "Tumors Remaining: " + objectCount.ToString();

        if (objectCount >= 50)
		{
            SceneManager.LoadScene(3);
        }
        else if (objectCount <= 0)
		{
            SceneManager.LoadScene(4);
        }
    }

    void CountObjectsWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Tumor");
        objectCount = objectsWithTag.Length;
    }
}
