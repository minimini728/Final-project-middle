using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public VariableJoystick joy;

    void FixedUpdate()
    {
        Vector2 temp = transform.position;
        if(joy.Horizontal > 0)
        {
            temp.x += moveSpeed * Time.deltaTime;
        } else if(joy.Horizontal < 0)
        {
            temp.x -= moveSpeed * Time.deltaTime;
        }


        if (joy.Vertical > 0)
        {
            temp.y += moveSpeed * Time.deltaTime;
        }
        else if (joy.Vertical < 0)
        {
            temp.y -= moveSpeed * Time.deltaTime;
        }

        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
          
            HGameManager.instance.PlayerMiniGame();
  //          HGameManager.instance.PlayerDied();
        }   
        if(target.tag == "Goal")
        {
            HGameManager.instance.ReachGold();
//          HGameManager.instance.PlayerReacheGoal();
        }
    }
}
