using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWord : MonoBehaviour
{
    public Door Door;
    public SpriteRenderer Renderer;
    public Sprite PassWordCo;

    void Update()
    {
        if(Door.IsOpen == true)
        {
            Renderer.sprite = PassWordCo;
        }
    }
}
