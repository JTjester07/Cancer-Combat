using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TumorTracker : MonoBehaviour
{
    public static int objectCount;
    public static int tumorsKilled = 0;
    public static int totalTumorsKilled = 0;
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
        objectCount = 0; // Reset the object count

        foreach (GameObject obj in objectsWithTag)
        {
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteRenderer.enabled)
            {
                objectCount++;
            }
        }
    }
}
