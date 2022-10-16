using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemy : MonoBehaviour
{

    public float moveSpeed = 4f;

    [SerializeField]
    private bool moveLeft;
    

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }

     void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bounce")
        {
            moveLeft = !moveLeft;
        }
    }
}
