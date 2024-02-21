using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard_Door : MonoBehaviour
{
    public static KeyCard_Door Instance { get; private set; }

    public GameObject Key;
    public bool OnCol;
    public Animator anim;
    public Collider2D col;
    public Collider2D col2;
    public bool IsOpen = false;
    public string KeyCard_Color;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (KeyCard_Color)
        {
            case "Red":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Red == true)
                    {
                        anim.SetTrigger("Open");
                        IsOpen = true;
                    }
                    break;
                }
           case "Blue":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Blue == true)
                    {
                        anim.SetTrigger("Open");
                        IsOpen = true;

                    }
                    break;
                }
            case "Green":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Green == true)
                    {
                        anim.SetTrigger("Open");
                        IsOpen = true;

                    }
                    break;
                }
            case "Yellow":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Yellow == true)
                    {
                        anim.SetTrigger("Open");
                        IsOpen = true;

                    }
                    break;
                }
        }

    }
    void open()
    {
        col.enabled = false;
        Debug.Log("����");
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
