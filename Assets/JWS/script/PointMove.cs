using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public Transform[] point;
    public float waitTime;
    int currentPointIndex;

    public bool once;

    void Start()
    {
        
    }

    void Update()
    {

        //Vector2 dir = (point[currentPointIndex].position - transform.position).normalized;
        //dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        //rb.velocity = dir * WalkSpeed;


        if (transform.position != point[currentPointIndex].position)
        {

            transform.position = Vector2.MoveTowards(transform.position, point[currentPointIndex].position, speed * Time.deltaTime);

            
        }
        else
        {
            if(once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
            
        }
    }
    IEnumerator Wait()
    {
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
        //rb.velocity = Vector2.zero;
    }
}
