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

    public int Index = -1;

    public GameObject[] Keys;
    public RectTransform KeysPosR;
    public RectTransform KeysPosB;
    public RectTransform KeysPosG;
    public RectTransform KeysPosY;
    public RectTransform KeysPosKey;

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
        float MoveX;
        KeyCard_Red = true;
        Keys[0].SetActive(true);
        Index += 1;
        MoveX = KeysPosR.anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPosR.anchoredPosition = new Vector2(MoveX, KeysPosR.anchoredPosition.y);



    }

    public void KeyCardBlue()
    {
        float MoveX;
        KeyCard_Blue = true;
        Keys[1].SetActive(true);
        Index += 1;
        MoveX = KeysPosB.anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPosB.anchoredPosition = new Vector2(MoveX, KeysPosB.anchoredPosition.y);

    }

    public void KeyCardGreen()
    {
        float MoveX;

        KeyCard_Green = true;
        Keys[2].SetActive(true);
        Index += 1;
        MoveX = KeysPosG.anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPosG.anchoredPosition = new Vector2(MoveX, KeysPosG.anchoredPosition.y);


    }

    public void KeyCardYellow()
    {
        float MoveX;

        KeyCard_Yellow = true;
        Keys[3].SetActive(true);
        Index += 1;

        MoveX = KeysPosY.anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPosY.anchoredPosition = new Vector2(MoveX, KeysPosY.anchoredPosition.y);

    }


}
