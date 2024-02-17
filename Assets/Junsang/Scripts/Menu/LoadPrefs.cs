using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadPrefs : MonoBehaviour
{
    [Header("General Setting")]
    [SerializeField] private MenuController menuController;
    [SerializeField] private bool canUse;

    [Header("Volume Setting")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Quality Setting")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("FullScreen Setting")]
    [SerializeField] private Toggle fullScreenToggle;

    private void Awake()
    {
        if(canUse)
        {
            if (PlayerPrefs.HasKey("masterMusicVolume"))
            {
                float localMusicVolume = PlayerPrefs.GetFloat("masterMusicVolume");
                musicSlider.value = localMusicVolume;
                AudioManager.Instance.SetMusicVolume(localMusicVolume);
            }
            if (PlayerPrefs.HasKey("masterSFXVolume"))
            {
                float localSFXVolume = PlayerPrefs.GetFloat("masterSFXVolume");
                sfxSlider.value = localSFXVolume;
                AudioManager.Instance.SetSFXVolume(localSFXVolume);
            }
            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }
            if (PlayerPrefs.HasKey("masterFullScreen"))
            {
                int localFullScreen = PlayerPrefs.GetInt("masterFullScreen");

                if(localFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }
        }
    }
}
