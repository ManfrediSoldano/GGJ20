using System.Collections;
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


    void Start()
    {
        startGame.onClick.AddListener(Continue);
        quitGame.onClick.AddListener(Quit);
        InputManager.OnMove += Move;
    }


    private void OnDestroy()
    {
        InputManager.OnMove -= Move;
    }
    private void Move(int playerNumber, float mov)
    {
        Debug.Log("Requested a vertical move", this);

        if (mov > 0)
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
        else
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


    private void Quit()
    {
        if (!blockLoading)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            blockLoading = true;
        }
    }

    private void Continue()
    {
        gameController.PauseGame(1);
    }
}
