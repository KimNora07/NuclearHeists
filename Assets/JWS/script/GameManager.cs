using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public bool KeyCard_Red = false;
    public bool KeyCard_Blue = false;
    public bool KeyCard_Green = false;
    public bool KeyCard_Yellow = false;


    public void GameOver()
    {
        
    }

    public void KeyCardRed()
    {
        KeyCard_Red = true;
    }

    public void KeyCardBlue()
    {
        KeyCard_Blue = true;
    }

    public void KeyCardGreen()
    {
        KeyCard_Green = true;
    }

    public void KeyCardYellow()
    {
        KeyCard_Yellow = true;
    }

}
