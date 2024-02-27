using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Rigidbody2D rb;

    private void Start()
    {

    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void FixedUpdate()
    {
        Vector3 dir = (target.position - transform.position).normalized;

        rb.velocity = dir * speed;
    }
}
