using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSlider : MonoBehaviour
{
    public static AudioSlider instance;

    public float musicVolume;
    public float sfxVolume;

    private void OnEnable()
    {
        musicVolume = 1f;
        sfxVolume = 1f;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        LoadVolumes();
    }

    private void SaveVolumes()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

        PlayerPrefs.Save();
    }

    private void LoadVolumes()
    {

        if (PlayerPrefs.HasKey("MusicVolume"))
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");

        if (PlayerPrefs.HasKey("SFXVolume"))
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
    }

    private void OnApplicationQuit()
    {
        SaveVolumes();
    }
}
