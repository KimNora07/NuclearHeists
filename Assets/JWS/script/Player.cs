using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public SpriteRenderer Renderer;

    public List<Sprite> nSprites;

    public List<Sprite> neSprites;

    public List<Sprite> eSprites;

    public List<Sprite> seSprites;

    public List<Sprite> sSprites;

    public float WalkSpeed;

    public float FrameRate;

    float IdleTime;

    Vector2 dir;

    void Start()
    {

    }

    void Update()
    {
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        rb.velocity = dir * WalkSpeed;


        SpriteFilp();

        SetSprite();


    }
    void SetSprite()
    {
        List<Sprite> dirSprite = GetSpriteDir();

        if (dirSprite != null)
        {
            float PlayTime = Time.time - IdleTime;
            int TotalFrame = (int)(PlayTime * FrameRate);
            int Frame = TotalFrame % dirSprite.Count;

            Renderer.sprite = dirSprite[Frame];
        }
        else
        {
            IdleTime = Time.time;
        }
    }

    void SpriteFilp()
    {
        if (!Renderer.flipX && dir.x < 0)
        {
            Renderer.flipX = true;
        }
        else if (Renderer.flipX && dir.x > 0)
        {
            Renderer.flipX = false;
        }
    }

    List<Sprite> GetSpriteDir()
    {
        List<Sprite> selectsprite = null;

        if (dir.y > 0)
        {
            if(Mathf.Abs(dir.x) > 0)
            {
                selectsprite = neSprites;
            }
            else
            {
                selectsprite = nSprites;
            }
        }
        else if(dir.y < 0)
        {
            if (Mathf.Abs(dir.x) > 0)
            {
                selectsprite = seSprites;
            }
            else
            {
                selectsprite = sSprites;
            }
        }
        else
        {
            if (Mathf.Abs(dir.x) > 0)
            {
                selectsprite = eSprites;
            }
        }

        return selectsprite;
    }
}
