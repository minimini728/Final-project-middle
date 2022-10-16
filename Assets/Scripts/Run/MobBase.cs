using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 startPosition;

    private void OnEnable()
    {
        transform.position = startPosition;
    }


    void Update()
    {   
        if(RGameManager.instance.isPlay)
        transform.Translate(Vector2.left * Time.deltaTime * RGameManager.instance.gameSpeed);

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
