using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairManager : MonoBehaviour
{
    public GameObject player;
    //public Collider2D col;

    public float x;
    public float y;
    public bool OnCol = false;

    public GameObject Key;

    private void Start()
    {
        //col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OnCol == true)
        {
            player.transform.position = new Vector3(x, y, 0);
            Debug.Log("�̵�");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCol = true;
            Key.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Key.SetActive(false);
        OnCol = false;
    }
}

