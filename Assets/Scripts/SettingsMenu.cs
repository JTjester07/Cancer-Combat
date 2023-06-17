using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void difficulty(int val)
    {
        // medium

        if (val == 0)
		{
            SpawnTumors.numberOfPrefabs = 5;
            spawnTumor.difficulty = 0;
        }

        // easy

        if (val == 1)
        {
            SpawnTumors.numberOfPrefabs = 4;
            spawnTumor.difficulty = 10;
        }

        // hard

        if (val == 2)
        {
            SpawnTumors.numberOfPrefabs = 6;
            spawnTumor.difficulty = -5;
        }
    }
}
