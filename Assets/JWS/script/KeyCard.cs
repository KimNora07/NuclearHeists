using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public KeyCard_Door Door;
    private SpriteRenderer Renderer;
    public Sprite KeyCardCo;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Door.IsOpen == true)
        {
            Renderer.sprite = KeyCardCo;
        }
    }
}
