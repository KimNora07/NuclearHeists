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
    public bool once;


    public GameObject player;
    public bool IsFind = false;
    bool chase = false;
    public float time;
    bool OnAngle = false;
    
    public GameObject AnglePos;


    

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

    }

    void Update()
    {
        checkAngle();
        
        Anim();
        MakeDirToPlayer();

        if(chase == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(chase == false)
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

        if(dir.x != 0 || dir.y != 0)
        {
            Lastdir = dir;
        }
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
                time += Time.deltaTime;
                if (time >= 1.5f && chase == false)
                {
                    time = 0;
                    chase = true;
                }


            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                chase = false;
                time = 0;
                OnAngle = false;

            }
        }
    }

    void checkAngle()
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


        //if (dir.x > 0 || dir.y != 0)
        //{
        //    AnglePos.transform.rotation = Quaternion.Euler(0, 0, 180);
        //}


        //if (dir.x > 0 || dir.y != 0)
        //{
        //    AnglePos.transform.rotation = Quaternion.Euler(0, 0, 180);
        //}


        //if (dir.x > 0 || dir.y != 0)
        //{
        //    AnglePos.transform.rotation = Quaternion.Euler(0, 0, 180);
        //}


        //if (dir.x > 0 || dir.y != 0)
        //{
        //    AnglePos.transform.rotation = Quaternion.Euler(0, 0, 180);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnAngle = true;
        }
    }
}