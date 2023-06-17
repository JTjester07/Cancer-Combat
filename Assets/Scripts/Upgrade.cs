using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public void UpgradeDamage()
    {
        Shooting.damageUpgrade += 1;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeHealth()
    {
        TakeDamage.Health += 25;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeSpeed()
    {
        if (Movement.moveSpeed < 50)
        {
            Movement.moveSpeed += 5;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
