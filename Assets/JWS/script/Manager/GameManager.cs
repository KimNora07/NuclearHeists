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

    public RectTransform[] KeysPos;

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
        MoveX = KeysPos[0].anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPos[0].anchoredPosition = new Vector2(MoveX, KeysPos[0].anchoredPosition.y);
    }

    public void KeyCardBlue()
    {
        float MoveX;
        KeyCard_Blue = true;
        Keys[1].SetActive(true);
        Index += 1;
        MoveX = KeysPos[1].anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPos[1].anchoredPosition = new Vector2(MoveX, KeysPos[1].anchoredPosition.y);
    }

    public void KeyCardGreen()
    {
        float MoveX;

        KeyCard_Green = true;
        Keys[2].SetActive(true);
        Index += 1;
        MoveX = KeysPos[2].anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPos[2].anchoredPosition = new Vector2(MoveX, KeysPos[2].anchoredPosition.y);
    }

    public void KeyCardYellow()
    {
        float MoveX;

        KeyCard_Yellow = true;
        Keys[3].SetActive(true);
        Index += 1;

        MoveX = KeysPos[3].anchoredPosition.x;
        if (MoveX == 0)
        {
            MoveX = 822;
        }
        MoveX -= 122 * Index;
        KeysPos[3].anchoredPosition = new Vector2(MoveX, KeysPos[3].anchoredPosition.y);
    }

    public void UseKeyCard(int num)
    {
        Index -= 1;
        Keys[num].SetActive(false);
        KeysPos[num].anchoredPosition = new Vector2(822, KeysPos[num].anchoredPosition.y);
    }


}
