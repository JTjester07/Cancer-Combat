using UnityEngine;
using UnityEngine.UI;

public class SliderValueSaver : MonoBehaviour
{
    private Slider slider;
    public string saveKey = "SliderValue";

    private void Start()
    {
        // Get the Slider component from the parent GameObject
        slider = GetComponent<Slider>();

        // Load the saved value from PlayerPrefs
        float savedValue = PlayerPrefs.GetFloat(saveKey, 0f);

        // Set the slider value to the saved value
        slider.value = savedValue;
    }

    public void SaveSliderValue()
    {
        // Save the slider value to PlayerPrefs
        PlayerPrefs.SetFloat(saveKey, slider.value);
        PlayerPrefs.Save();
    }
}
