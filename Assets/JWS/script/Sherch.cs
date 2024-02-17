using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sherch : MonoBehaviour
{
    

    public float SherchTime;
    public float FindTime = 2;
    public bool Find = false;
    public bool Once = false;
    public bool OnCol = false;


    public Collider2D col;
    public GameObject Key;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && Once == false && OnCol == true)
        {
            SherchTime += Time.deltaTime;
            if (SherchTime >= FindTime)
            {
                Find = true;
                Once = true;

                col.enabled = false;
                Debug.Log("Ã£À½");
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
    }
}
