using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    void Update()
    {
        // Update the text component with the current value of Health
        healthText.text = "Health: " + TakeDamage.Health.ToString();
    }
}