using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public bool HaveKeyCard;
    public string AI_Type;
    public float radius;
    public LayerMask Layer;
    Animator anim;
    public Rigidbody2D rb;
    public float speed;
    public Transform[] point;
    private float waitTime;
    private int currentPointIndex;
    Vector2 dir;
    private Vector2 Lastdir;
    private bool once;


    private bool OnSteelArea = false;
    private bool SteelOnce = false;
    private bool IsFind = false;
    private bool gameOver = false;
    private bool OnAngle = false;
    
    public GameObject AnglePos;
    public GameObject Mark1;
    public GameObject Mark2;
    public GameObject RKey;
    public GameObject BKey;
    public GameObject GKey;
    public GameObject YKey;
    public GameObject Steelkey;
    public GameObject player;



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if (OnAngle == true)
        {
            MakeRay();
        }
        else
        {
            Mark2.SetActive(false);
        }

    }

    void Update()
    {
        if (HaveKeyCard)
        {
            SteelAtea();
        }
        CheckAngle();
        Anim();
        //MakeDirToPlayer();

        if(gameOver == true)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            //MakeRay();
            GameManager.Instance.GameOver();
            Mark1.SetActive(true);
            Mark2.SetActive(false);
        }
        if(gameOver == false)
        {
            
            MakeDir();

            if (transform.position != point[currentPointIndex].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, point[currentPointIndex].position, speed * Time.deltaTime);
                anim.SetBool("IsRun", true);
            }
            else
            {
                if (once == false)
                {
                    once = true;
                    StartCoroutine(Wait());

                }

            }
        }



    }
    IEnumerator Wait()
    {
        anim.SetBool("IsRun", false);
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < point.Length)
        {
            currentPointIndex++;

        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;

    }

    void MakeDir()
    {
        dir = ((Vector2)point[currentPointIndex].position - (Vector2)transform.position).normalized;


        if (dir.x != 0 || dir.y != 0)
        {
            Lastdir = dir;
        }

    }

    //void MakeDirToPlayer()
    //{
    //    dir = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;

    //}

    void Anim()
    {
        anim.SetFloat("AIx", dir.x);
        anim.SetFloat("AIy", dir.y);
        anim.SetFloat("LastAIx", Lastdir.x);
        anim.SetFloat("LastAIy", Lastdir.y);
    }

    void MakeRay()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            IsFind = ray.collider.CompareTag("Player");
            if (IsFind)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                if(gameOver == false)
                {
                    GameManager.Instance.time += Time.deltaTime;
                }
                else
                {
                    GameManager.Instance.time = 0;
                }
                    
                
                Mark1.SetActive(false);
                Mark2.SetActive(true);
                if (GameManager.Instance.time >= GameManager.Instance.chaseTime && gameOver == false)
                {
                    GameManager.Instance.time = GameManager.Instance.chaseTime;
                    gameOver = true;
                    Mark1.SetActive(true);
                    Mark2.SetActive(false);
                }


            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                gameOver = false;
                GameManager.Instance.time = 0;
                OnAngle = false;
                Mark1.SetActive(false);
                Mark2.SetActive(false);


            }
        }
    }

    void CheckAngle()
    {
        if (dir.y >= 0.9)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, 180);
        }


        if (dir.x >= 0.9)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, 90);
        }


        if (dir.y <= -0.9)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if (dir.x <= -0.9)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, -90);
        }


        if (dir.x >= 0.1 && dir.y >= 0.1)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, 135);
        }


        if (dir.x >= 0.1 && dir.y <= -0.1)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, 45);
        }


        if (dir.x <= -0.1 && dir.y <= -0.1)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, -45);
        }


        if (dir.x <= -0.1 && dir.y >= 0.1)
        {
            AnglePos.transform.rotation = Quaternion.Euler(0, 0, -135);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnAngle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnAngle = false;
            Mark1.SetActive(false);
            GameManager.Instance.time = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Mark1.SetActive(true);
        Mark2.SetActive(false);
        GameManager.Instance.GameOver();
    }


    void SteelAtea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, Layer);

        if (colliders != null && colliders.Length > 0 && SteelOnce == false)
        {
            foreach (Collider2D col in colliders)
            {
                if (!SteelOnce)
                {
                    Steelkey.SetActive(true);
                    Debug.Log("영역안");
                    OnSteelArea = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        OnSteelArea = false;
                        SteelOnce = true;
                        switch (AI_Type)
                        {
                            case "R":
                                {
                                    GameManager.Instance.KeyCardRed();
                                    RKey.SetActive(false);
                                    break;
                                }
                            case "B":
                                {
                                    GameManager.Instance.KeyCardBlue();
                                    BKey.SetActive(false);
                                    break;
                                }
                            case "G":
                                {
                                    GameManager.Instance.KeyCardGreen();
                                    GKey.SetActive(false);
                                    break;
                                }
                            case "Y":
                                {
                                    GameManager.Instance.KeyCardYellow();
                                    YKey.SetActive(false);
                                    break;
                                }
                        }

                        
                        Steelkey.SetActive(false);

                        Debug.Log("훔침");
                    }
                }

            }
        }
        else
        {
            Steelkey.SetActive(false);
            OnSteelArea = false;
            Debug.Log("영역밖");
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}