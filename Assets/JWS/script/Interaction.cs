using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float SherchTime;
    public float FindTime = 2;
    public bool Find = false;
    public bool Once = false;
    private bool OnCol = false;
    public string ContainItem;
    public Collider2D col;
    public GameObject Key;


    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Once == false && OnCol == true)
        {
            SherchTime += Time.deltaTime;
            if (SherchTime >= FindTime)
            {
                switch (ContainItem)
                {
                    case "RedKeyCard":
                        {
                            GameManager.Instance.KeyCardRed();
                            Find = true;
                            col.enabled = false;
                            break;
                        }
                    case "BlueKeyCard":
                        {
                            GameManager.Instance.KeyCardBlue();
                            Find = true;
                            col.enabled = false;
                            break;
                        }
                    case "GreenKeyCard":
                        {
                            GameManager.Instance.KeyCardGreen();
                            Find = true;
                            col.enabled = false;
                            break;
                        }
                    case "YellowKeyCard":
                        {
                            GameManager.Instance.KeyCardYellow();
                            Find = true;
                            col.enabled = false;
                            break;
                        }
                    case "Nuke":
                        {
                            GameManager.Instance.Claer();
                            Find = true;
                            col.enabled = false;
                            break;
                        }
                }
            }
        }
        else
        {
            SherchTime = 0;
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

