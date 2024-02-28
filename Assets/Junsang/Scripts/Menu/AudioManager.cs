using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }

    public Sound[] musicSound;
    public Sound[] sfxSound;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    const string MIXER_MUSIC = "BGMVolume";
    const string MIXER_SFX = "SFXVolume";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float value)
    {
        MenuController.Instance.musicVolume = value;
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        MenuController.Instance.sfxVolume = value;
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20); 
    }

    public void PlayMusic(string name)
    {  
        Sound sound = Array.Find(musicSound, x => x.name == name);  

        if (sound == null)
        {                  
            Debug.Log("Sound Not Found!");
        }
        else
        {
            musicSource.clip = sound.clip; 
            musicSource.Play();        
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSound, x => x.name == name); 

        if (sound == null)
        {              
            Debug.Log("Sound Not Found!");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);  
        }
    }


}
