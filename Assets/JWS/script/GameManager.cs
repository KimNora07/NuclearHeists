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

    public Image R_KEY;
    public Image B_KEY;
    public Image G_KEY;
    public Image Y_KEY;

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
        R_KEY.enabled = true;
        Debug.Log("빨간키카드 찾음");
    }

    public void KeyCardBlue()
    {
        KeyCard_Blue = true;
        B_KEY.enabled = true;
    }

    public void KeyCardGreen()
    {
        KeyCard_Green = true;
        G_KEY.enabled = true;

    }

    public void KeyCardYellow()
    {
        KeyCard_Yellow = true;
        Y_KEY.enabled = true;
    }

}
