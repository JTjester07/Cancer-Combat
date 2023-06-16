using UnityEngine;
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
            // Causes a loss
		}
        else if (objectCount <= 0)
		{
            // Causes a win
		}
    }

    void CountObjectsWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Tumor");
        objectCount = objectsWithTag.Length;
    }
}
