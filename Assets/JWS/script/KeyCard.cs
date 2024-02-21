using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public KeyCard_Door Door;
    public SpriteRenderer Renderer;
    public Sprite KeyCardCo;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Door.IsOpen == true)
        {
            Renderer.sprite = KeyCardCo;
        }
    }
}
