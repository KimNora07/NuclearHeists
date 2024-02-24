using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator anim;
    private Vector2 movedir;
    private Vector2 lastmovedir;
    public GameObject E_KEY;


    void Update()
    {
        if(GameManager.Instance.OnSteelArea == true)
        {
            E_KEY.SetActive(true);
            Debug.Log("»ý¼º");
        }
        else
        {
            E_KEY.SetActive(false);
        }
        MakeDir();
        Anim();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void MakeDir()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if((x == 0 && y == 0) && movedir.x != 0 || movedir.y != 0)
        {
            lastmovedir = movedir;
        }

        movedir = new Vector2(x, y).normalized;
    }

    void Move()
    {
        //rb.velocity = new Vector2(movedir.x * moveSpeed, movedir.y * moveSpeed);

        rb.velocity = movedir * moveSpeed;
    }

    void Anim()
    {
        anim.SetFloat("X", movedir.x);
        anim.SetFloat("Y", movedir.y);
        anim.SetFloat("Move", movedir.magnitude);
        anim.SetFloat("lastMX", lastmovedir.x);
        anim.SetFloat("lastMY", lastmovedir.y);
    }
}
