using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public float time;
    public float chaseTime;



    public Slider findSlider;

    public bool KeyCard_Red = false;
    public bool KeyCard_Blue = false;
    public bool KeyCard_Green = false;
    public bool KeyCard_Yellow = false;

    public GameObject[] Keys;

    private void Update()
    {
        findSlider.value = (float)time / (float)chaseTime;
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
    }

    public void KeyCardRed()
    {
        KeyCard_Red = true;
        Keys[0].SetActive(true);

    }

    public void KeyCardBlue()
    {
        KeyCard_Blue = true;
        Keys[1].SetActive(true);

    }

    public void KeyCardGreen()
    {
        KeyCard_Green = true;
        Keys[2].SetActive(true);


    }

    public void KeyCardYellow()
    {
        KeyCard_Yellow = true;
        Keys[3].SetActive(true);

    }

}
