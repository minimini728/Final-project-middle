using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject Die;

    void OnTriggerEnter2D(Collider2D col)
    {
        SfxControl.SfxFried();
        Instantiate(Die, col.gameObject.transform.position, Quaternion.identity);
        Destroy(col.gameObject);
    }
}
