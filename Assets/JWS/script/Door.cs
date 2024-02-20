using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Key;
    public bool OnCol;
    public Animator anim;
    public Collider2D col;
    public Collider2D col2;
    public bool IsCo = true;
    public bool IsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OnCol == true)
        {
            if (IsCo)
            {
                anim.SetTrigger("Open");
                col2.enabled = false;
                IsOpen = true;

            }
        }

    }
    void open()
    {
        col.enabled = false;
        Debug.Log("¿­¸²");
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
