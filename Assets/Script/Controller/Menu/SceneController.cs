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
    void Start()
    {

        startGame.onClick.AddListener(LoadScene);
        quitGame.onClick.AddListener(Quit);
        InputManager.OnVerticalMove += VerticalMove;

        startGame.Select();
    }

    private void OnDestroy()
    {
        InputManager.OnVerticalMove -= VerticalMove;
    }

    private void VerticalMove(float mov)
    {
     
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
