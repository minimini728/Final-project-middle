using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemy2 : MonoBehaviour
{

    public float moveSpeed = 4f;

    [SerializeField]
    private bool moveDown;


    // Update is called once per frame
    void Update()
    {
        if (moveDown)
        {
            Vector3 temp = transform.position;
            temp.y -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.y += moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bounce")
        {
            moveDown = !moveDown;
        }
    }
}
