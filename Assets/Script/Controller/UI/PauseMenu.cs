﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button startGame;
    public Button quitGame;

    private int position = 0;
    public bool blockLoading = false;
    public GameController gameController;

    public bool isActive = false;

    void Start()
    {
        startGame.onClick.AddListener(Continue);
        quitGame.onClick.AddListener(Quit);
        InputManager.OnVerticalMove += VerticalMove;
        InputManager.OnJump += Accept;
        InputManager.OnPunch += Back;
        startGame.Select();
    }

    private void OnDisable()
    {
        isActive = false;
    }

    private void OnEnable()
    {
        isActive = true;
        startGame.Select();
    }


    private void OnDestroy()
    {
        InputManager.OnVerticalMove -= VerticalMove;
        InputManager.OnJump -= Accept;
    }


    private void Back(int player)
    {
        if (isActive)
        {

            Continue();

        }
    }
    private void Accept(int player)
    {
        if (isActive)
        {
            if (position == 0)
            {
                Continue();
            }
            else
            {
                Quit();
            }
        }
    }


    private void VerticalMove(float mov)
    {
        Debug.Log("Requested a move", this);

        if (mov > 0)
        {
            if (position == 0)
            {

            }
            else
            {
                startGame.Select();
                position = 0;
            }
        }
        else
        {
            if (position == 0)
            {

                quitGame.Select();
                position = 1;
            }
            else
            {


            }
        }
    }


    private void Quit()
    {
        if (!blockLoading)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            blockLoading = true;
            gameController.PauseGame(1);
        }
    }

    private void Continue()
    {
        Debug.Log("Continue");
        gameController.PauseGame(1);
    }
}
