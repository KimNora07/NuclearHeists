using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
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

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Anim();
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

    void Anim()
    {
        anim.SetFloat("AIx", dir.x);
        anim.SetFloat("AIy", dir.y);
        anim.SetFloat("LastAIx", Lastdir.x);
        anim.SetFloat("LastAIy", Lastdir.y);
    }
}