using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioController : MonoBehaviour
{

    public GameObject soundSystem;

    public AudioClip water;
    public AudioClip punch;
    public AudioClip death;
    public AudioClip destroyPipe; //
    public AudioClip repairPipe; //
    public AudioClip openDoor; //
    public AudioClip jump1; //
    public AudioClip jump2; //
    public AudioClip menu1;
    public AudioClip menu2;
    public AudioClip powerUp;
    public AudioClip punch1;
    public AudioClip punch2;

    public AudioClip alarm;
    public AudioClip victory;

    private void Play(AudioClip audioClip)
    {
        GameObject reproducer = Instantiate(soundSystem, this.transform);
        reproducer.GetComponent<Reproducer>().Play(audioClip);
    }

    internal void Door()
    {
        Play(openDoor);
    }

    public void Punch()
    {
        Play(punch1);
    }


     public void Repair()
    {
        Play(repairPipe);
    }

    internal void Jump()
    {
        Play(jump1);
    }

    internal void Broke()
    {
        Play(destroyPipe);
    }
}
