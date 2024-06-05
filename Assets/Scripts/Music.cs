using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    private void Start()
    {
        src.clip = sfx1;
        src.Play();
    }
}
