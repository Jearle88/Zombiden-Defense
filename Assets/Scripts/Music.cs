using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    // script to play music (not really needed I think but ensures music is played)
    private void Start()
    {
        src.clip = sfx1;
        src.Play();
    }
}
