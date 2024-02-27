using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float speed;
    public bool IsFind = false;
    public bool Find = false;
    public Transform player;
    public GameObject Bullet;
    public Transform FirePos;
    Vector3 dir = new Vector3(0, 0, 1);




    void FixedUpdate()
    {
        transform.RotateAround(transform.position, dir, speed);
        if (Find)
        {
            MakeRay();
        }
    }


    void MakeRay()
    {
        Vector3 PlayerDir = player.position - transform.position;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            IsFind = ray.collider.CompareTag("Player");
            if (IsFind)
            {
                float angle = Mathf.Atan2(PlayerDir.y, PlayerDir.x) * Mathf.Rad2Deg;
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GameObject bulletobj = Instantiate(Bullet, FirePos.position, Quaternion.identity);
                Bullet bulletscript = bulletobj.GetComponent<Bullet>();
                bulletscript.SetTarget(player);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Find = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Find = false;
    }
}
