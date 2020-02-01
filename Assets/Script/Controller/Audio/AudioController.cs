using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    AudioSource audioData;

    public AudioClip water;
    public AudioClip punch;
    public AudioClip death;
    public AudioClip destroyPipe;
    public AudioClip repairPipe;
    public AudioClip openDoor;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip menu1;
    public AudioClip menu2;
    public AudioClip powerUp;
    public AudioClip punch1;
    public AudioClip punch2;

    public AudioClip alarm;
    public AudioClip victory;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void Punch()
    {
        audioData.clip = punch1;
        audioData.Play(0);
    }


    public void DestroyPipe()
    {
        audioData.clip = destroyPipe;
        audioData.Play(0);
    }

    
    public void RepairPipe()
    {
        audioData.clip = repairPipe;
        audioData.Play(0);
    }
}
