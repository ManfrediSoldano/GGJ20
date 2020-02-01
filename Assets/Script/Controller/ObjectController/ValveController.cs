﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour, SceneObjectController
{
    public ValveStatus status;
    public WaterController waterController;
    public Color brokenColor;
    SpriteRenderer m_SpriteRenderer;
    public GameObject audioManager;


    public void ActivateObject(GameObject player)
    {
        if(status == ValveStatus.BROKEN && (player.GetComponent<Player>() is Fixer))
        {
            FixedJoint();
        } else if(status == ValveStatus.OPEN && (player.GetComponent<Player>() is Destroyer))
        {
            Broke();
        }
    }

    public void Awake()
    {
        waterController = GameObject.Find("WaterController").GetComponent<WaterController>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.Find("AudioManager");

    }

    /// <summary>
    /// Change the status of the pipe to the broken one.
    /// Increase the water increase speed.
    /// </summary>
    public void Broke()
    {
        status = ValveStatus.BROKEN;
        waterController.openPipes++;
        m_SpriteRenderer.color = brokenColor;
        audioManager.GetComponent<AudioController>().Broke();
    }

    /// <summary>
    /// Change the status of the pipe to the working/open/Fixed one.
    /// Reduce the water increase speed.
    /// </summary>
    public void FixedJoint()
    {
        status = ValveStatus.OPEN;
        waterController.openPipes--;
        m_SpriteRenderer.color = Color.white;
        audioManager.GetComponent<AudioController>().Repair();
    }


}
