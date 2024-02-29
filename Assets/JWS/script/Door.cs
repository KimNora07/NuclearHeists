using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door Instance;

    public GameObject Key;
    public bool OnCol;
    public Animator anim;
    public Collider2D col;
    public Collider2D col2;
    public bool IsCo = false;
    public bool IsOpen = false;

    public GameObject keyPad;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        IsCo = false;
        keyPad.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OnCol == true)
        {
            if (!IsCo)
            {
                Time.timeScale = 0f;
                keyPad.SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && OnCol == true)
        {
            Time.timeScale = 1f;
            keyPad.SetActive(false);
        }

        if(OnCol && IsCo)
        {
            Time.timeScale = 1f;

            keyPad.SetActive(false);
            anim.SetTrigger("Open");
            col2.enabled = false;
            IsOpen = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Key.SetActive(true);
            OnCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Key.SetActive(false);
        OnCol = false;
    }
}
