using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button startGame;
    public Button quitGame;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    public bool blockLoading = false;

    private int position = 0;

    void Start()
    {

        startGame.onClick.AddListener(LoadScene);
        quitGame.onClick.AddListener(Quit);
        InputManager.OnVerticalMove += VerticalMove;
        InputManager.OnJump += Accept;

        startGame.Select();
    }

    private void OnDestroy()
    {
        InputManager.OnVerticalMove -= VerticalMove;
        InputManager.OnJump -= Accept;

    }



    private void Accept(int player)
    {
        if (position == 0)
        {
            LoadScene();
        }
        else
        {
            Quit();
        }
    }


    private void VerticalMove(float mov)
    {
        Debug.Log("Requested a vertical move", this);

         if (mov > 0)
        {
            if (position == 0)
            {
                Debug.Log("Quit Game", this);
                quitGame.Select();
                position = 1;
            } else
            {
                Debug.Log("Start Game", this);
                startGame.Select();
                position = 0;
            }
        } else
        {
            if (position == 0)
            {

                quitGame.Select();
                position = 1;
            }
            else
            {
                startGame.Select();
                position = 0;
                
            }
        }
    }

    private void LoadScene()
    {
        if (!blockLoading)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            blockLoading = true;
        }
    }

    private void Quit()
    {
        Application.Quit();
    }
}
