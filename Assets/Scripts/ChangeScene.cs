using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void PlayGame()
	{
        SceneManager.LoadScene(1);
	}
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        Shooting.damageUpgrade = 1;
        TakeDamage.Health = 100;
        Movement.moveSpeed = 5;
        TimeTracker.gameTime = 0;
        SceneManager.LoadScene(0);
    }
}
