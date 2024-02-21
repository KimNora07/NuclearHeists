using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{


    public float SherchTime;
    public float FindTime = 2;
    public bool Find = false;
    public bool Once = false;
    public bool OnCol = false;
    public bool IsOpen = false;


    public Collider2D col;
    public GameObject Key;
    public GameObject Key2;

    public Animator anim;

    public string ContainItem;

    void Start()
    {
        //col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && Once == false && OnCol == true && IsOpen == false)
        {
            SherchTime += Time.deltaTime;
            if (SherchTime >= FindTime)
            {
                
                Once = true;
                IsOpen = true;
                Key.SetActive(false);
                Key2.SetActive(true);
                anim.SetBool("Open", true);
            }
        }
        else if(Input.GetKeyDown(KeyCode.E) && IsOpen == true && Find == false)
        {
            switch (ContainItem)
            {
                case "RedKeyCard":
                    {
                        GameManager.Instance.KeyCardRed();
                        Find = true;
                        col.enabled = false;
                        Debug.Log("빨간키카드 찾음");
                        break;
                    }
                case "BlueKeyCard":
                    {
                        GameManager.Instance.KeyCardBlue();
                        Find = true;
                        col.enabled = false;
                        Debug.Log("파랑키카드 찾음");
                        break;
                    }
                case "GreenKeyCard":
                    {
                        GameManager.Instance.KeyCardGreen();
                        Find = true;
                        col.enabled = false;
                        Debug.Log("초록키카드 찾음");
                        break;
                    }
                case "YellowKeyCard":
                    {
                        GameManager.Instance.KeyCardYellow();
                        Find = true;
                        col.enabled = false;
                        Debug.Log("노란키카드 찾음");
                        break;
                    }
            }
            //Find = true;
            //col.enabled = false;
            //Debug.Log("찾음");
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
            if(IsOpen == false)
            {
                Key.SetActive(true);
            }
            else
            {
                Key2.SetActive(true);
            }
            
            OnCol = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(IsOpen == false)
        {
            Key.SetActive(false);
        }
        else
        {
            Key2.SetActive(false);
        }
        
        OnCol = false;
    }
}
