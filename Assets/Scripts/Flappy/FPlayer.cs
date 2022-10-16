using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPlayer : MonoBehaviour
{
    [SerializeField] float FlappyPower = 550f;

    Rigidbody2D rb;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        startTime = Time.time + 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime)
            rb.isKinematic = false;

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector2(0f, FlappyPower), ForceMode2D.Force);
        }
    }
}
