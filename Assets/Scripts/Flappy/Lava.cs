using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] GameObject Die;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            SfxControl.SfxFried();
            Instantiate(Die, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
        
    }
}
