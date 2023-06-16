using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    void UpgradeDamage()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void UpgradeHealth()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void UpgradeSpeed()
    {
        if (Movement.moveSpeed < 50)
        {
            Movement.moveSpeed += 5;
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
