using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Player> playersList = new List<Player>();
    public int numberOfFixers;
    public int numberOfDestroyers;
    public SpawnManager spawnManager;
    public GameObject playerContainer;
    private int playerCounter = 1;
    //Timer variables
    public float timeLeft = 60.0f;
    public Text text;
    //Pause Handling
    private bool onPause = false;

    public GameObject pauseScreen;


    public void Awake()
    {
        InputManager.OnPause += PauseGame;
    }

    public void OnDestroy()
    {
        InputManager.OnPause -= PauseGame;
    }

    public void Start()
    {
        SpawnInitialPlayers();
    }

    void FixedUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.fixedDeltaTime;

            //seconds to sessaggesimale conversion
            int Minutes = ((int)Mathf.Round(timeLeft)) / 60;
            int Seconds = ((int)Mathf.Round(timeLeft) % 60);
            string timer = "";

            if (Minutes < 10) {
                timer = "0" + Minutes.ToString();
            }
            else {
                timer = Minutes.ToString();
            }

            if (Seconds < 10)
            {
                timer += ":0" + Seconds.ToString();
            }
            else
            {
                timer += ":" + Seconds.ToString();
            }

            text.text = timer;

        } else if (timeLeft < 0)
        {
            timeLeft = 0;
            text.text = "Game Over";
            WinConditions("Plumber");
        }
        else {
            text.text = "Game Over";
            WinConditions("Plumber");
            //Application.LoadLevel("gameOver");
        }
    }

    /// <summary>
    /// Spawn the numeber of players defined from the number of players value.
    /// </summary>
    private void SpawnInitialPlayers()
    {
        while (numberOfFixers > 0)
        {
            GameObject playerGO = spawnManager.SpawnNewPlayer(PlayerType.FIXER);
            if (playerGO != null)
            {
                playerGO.transform.parent = playerContainer.transform;
                Player player = playerGO.GetComponent<Player>();
                playersList.Add(player);
                numberOfFixers--;
                player.playerNumber = playerCounter;
                playerCounter++;
            }
            else
            {
                Debug.LogError("Not enough spawn point at the start (FIXERS) ", this);
            }
        }

        while (numberOfDestroyers > 0)
        {
            GameObject playerGO = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);

            if (playerGO != null)
            {
                playerGO.transform.parent = playerContainer.transform;
                Player player = playerGO.GetComponent<Player>();
                playersList.Add(player);
                numberOfDestroyers--;
                player.playerNumber = playerCounter;
                playerCounter++;
            }
            else
            {
                Debug.LogError("Not enough spawn point at the start (DESTROYERS)", this);
            }
        }

    }

    internal void RemovePlayer(Player player)
    {
        playersList.Remove(player);
        String name = player.name;
        int playerNumber = player.GetComponent<Player>().playerNumber;
        GameObject newPlayer;
        if (player is Fixer)
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.FIXER);
        }
        else
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
        }
        if (newPlayer != null)
        {
            newPlayer.GetComponent<Player>().playerNumber = playerNumber;
            newPlayer.transform.parent = playerContainer.transform;
            playersList.Add(newPlayer.GetComponent<Player>());
        } else
        {
            Debug.Log("Player " + name + " has been definately killed.");
            if (player is Destroyer) {
                WinConditions("Destroyer");
            }
        }
        Destroy(player.gameObject);

    }

    internal void Kill(Player player)
    {
        playersList.Remove(player);
        String name = player.name;
        int playerNumber = player.GetComponent<Player>().playerNumber;
        StartCoroutine(SpawnKilledEnemy(playerNumber, player is Destroyer, name));
        Destroy(player.gameObject);

    }

    private IEnumerator SpawnKilledEnemy(int playerNumber, bool isDestroyer, string name)
    {
        GameObject newPlayer;
        yield return new WaitForSeconds(4);
        if (!isDestroyer)
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.FIXER);
        }
        else
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
        }
        if (newPlayer != null)
        {
            newPlayer.GetComponent<Player>().playerNumber = playerNumber;
            newPlayer.transform.parent = playerContainer.transform;
            playersList.Add(newPlayer.GetComponent<Player>());
        }
        else
        {
            Debug.Log("Player " + name + " has been definately killed.");
            if (isDestroyer)
            {
                WinConditions("Destroyer");
            }
        }
    }

    public void PauseGame(int PlayerNumber) {
        if (onPause == false)
        {
            onPause = true;
            Time.timeScale = 0;
            text.text = "Pause";
            pauseScreen.SetActive(true);
        } else {
            onPause = false;
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    private bool alreadyFinished =false;
    void WinConditions(string winner) {
        if (alreadyFinished == false)
        {
            if ((winner == "Destroyer" && timeLeft == 0) || (winner == "Plumber" && playersList.Count == 0))
            {
                Debug.Log("Tie");
            }
            else if (winner == "Plumber")
            {
                Debug.Log("Plumber Wins");
            }
            else if (winner == "Destroyer")
            {
                Debug.Log("Destroyer Wins");
            }
            alreadyFinished = true;
        }

    }
}
