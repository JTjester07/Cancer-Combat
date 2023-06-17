using UnityEngine;
using TMPro;

public class SaveDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    private void Start()
    {
        // Get the TMP_Dropdown component from the parent GameObject
        dropdown = GetComponent<TMP_Dropdown>();

        // Load the saved option from PlayerPrefs
        int savedOption = PlayerPrefs.GetInt("DropdownOption", 0); // 0 is the default value if no option is saved

        // Set the dropdown to the saved option
        dropdown.value = savedOption;
    }

    public void SaveOption()
    {
        // Save the selected option to PlayerPrefs
        int selectedOption = dropdown.value;
        PlayerPrefs.SetInt("DropdownOption", selectedOption);
    }
}
