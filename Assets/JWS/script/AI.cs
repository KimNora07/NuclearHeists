using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Animator anim;
    public Rigidbody2D rb;
    public float speed;
    public Transform[] point;
    public float waitTime;
    int currentPointIndex;
    Vector2 dir;
    private Vector2 Lastdir;
    private bool once;


    public GameObject player;
    private bool IsFind = false;
    private bool gameOver = false;
    //public float time;
    //public float chaseTime;
    bool OnAngle = false;
    
    public GameObject AnglePos;

    public GameObject Mark1;
    public GameObject Mark2;

    


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    { 
        if(OnAngle == true)
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
        CheckAngle();
        
        Anim();
        MakeDirToPlayer();

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

    void MakeDirToPlayer()
    {
        dir = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;

    }

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
    private void OnCollisionStay2D(Collision2D collision)
    {
        Mark1.SetActive(true);
        Mark2.SetActive(false);
        GameManager.Instance.GameOver();
    }
}