using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard_Door : MonoBehaviour
{
    public static KeyCard_Door Instance { get; private set; }

    public GameObject Key;
    private bool OnCol;
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
                        AudioManager.Instance.PlaySFX("ConfirmClick");
                        col2.enabled = false;
                        anim.SetTrigger("Open");
                        IsOpen = true;
                        GameManager.Instance.Keys[0].SetActive(false);
                    }
                    break;
                }
           case "Blue":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Blue == true)
                    {
                        AudioManager.Instance.PlaySFX("ConfirmClick");
                        col2.enabled = false;
                        anim.SetTrigger("Open");
                        IsOpen = true;
                        GameManager.Instance.Keys[1].SetActive(false);
                    }
                    break;
                }
            case "Green":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Green == true)
                    {
                        AudioManager.Instance.PlaySFX("ConfirmClick");
                        col2.enabled = false;
                        anim.SetTrigger("Open");
                        IsOpen = true;
                        GameManager.Instance.Keys[2].SetActive(false);

                    }
                    break;
                }
            case "Yellow":
                {
                    if (Input.GetKeyDown(KeyCode.E) && OnCol == true && GameManager.Instance.KeyCard_Yellow == true)
                    {
                        AudioManager.Instance.PlaySFX("ConfirmClick");
                        col2.enabled = false;
                        anim.SetTrigger("Open");
                        IsOpen = true;
                        GameManager.Instance.Keys[3].SetActive(false);

                    }
                    break;
                }
        }

    }
    void open()
    {
        col.enabled = false;
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
