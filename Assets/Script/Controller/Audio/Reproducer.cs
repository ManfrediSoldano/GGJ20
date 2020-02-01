using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproducer : MonoBehaviour
{
    AudioSource audioSource;
    bool alreadyStarted = false;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Play(AudioClip clip)
    {
        Debug.Log(clip.name +" "+ audioSource);
        audioSource.clip = clip;
        audioSource.Play(0);
        alreadyStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && alreadyStarted)
        {
            Destroy(this.gameObject);
        }
    }
}
