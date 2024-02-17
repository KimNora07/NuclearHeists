using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairManager : MonoBehaviour
{
    public LayerMask overLayer;
    public float r = 1.0f;

    public Transform[] StairPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StairF(0);
        StairF(1);
    }

    void StairF(int point)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(StairPoints[point].position, r, overLayer);

        foreach(Collider2D col in colliders)
        {
            switch (point)
            {
                case 0:
                    col.transform.position = new Vector3(-7, 25, 0);
                    break;
                case 1:
                    col.transform.position = new Vector3(-4, 0, 0);
                    break;
            }
            

            Debug.Log("´ÝÀ½");
        }

    }
    
}
