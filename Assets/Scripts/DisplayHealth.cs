using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private TakeDamage takeDamage;

    void Start()
    {
        takeDamage = FindObjectOfType<TakeDamage>();
    }

    void Update()
    {
        // Update the text component with the current value of Health
        healthText.text = "Health: " + takeDamage.Health.ToString();
    }
}