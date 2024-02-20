using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWord : MonoBehaviour
{
    public Door Door;
    public SpriteRenderer Renderer;
    public Sprite PassWordCo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Door.IsOpen == true)
        {
            Renderer.sprite = PassWordCo;
        }
    }
}
