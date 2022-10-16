using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxControl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip1, audioClip2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip1 = Resources.Load<AudioClip>("Die");
        audioClip2 = Resources.Load<AudioClip>("GetItem2");

    }

    // Update is called once per frame
    public static void SfxFried()
    {
        audioSource.PlayOneShot(audioClip1);
    }

    public static void SfxGetItem()
    {
        audioSource.PlayOneShot(audioClip2);
    }
}
