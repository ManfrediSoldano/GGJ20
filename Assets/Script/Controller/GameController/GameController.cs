using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Player> playersList = new List<Player>();
    public int numberOfFixers;
    public int numberOfDestroyers;
    public SpawnManager spawnManager;
    public GameObject playerContainer;


    public void Start()
    {
        SpawnInitialPlayers();
    }

    /// <summary>
    /// Spawn the numeber of players defined from the number of players value.
    /// </summary>
    private void SpawnInitialPlayers()
    {
        while (numberOfFixers > 0)
        {
            GameObject player = spawnManager.SpawnNewPlayer(PlayerType.FIXER);
            if (player != null)
            {              
                player.transform.parent = playerContainer.transform;
                playersList.Add(player.GetComponent<Player>());
                numberOfFixers--;
            }
            else
            {
                Debug.LogError("Not enough spawn point at the start (FIXERS) ", this);
            }
        }

        while (numberOfDestroyers > 0)
        {
            GameObject player = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
            if (player != null)
            {
                player.transform.parent = playerContainer.transform;
                playersList.Add(player.GetComponent<Player>());
                numberOfDestroyers--;
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
        GameObject newPlayer;
        if (player is Fixer)
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.FIXER);
        }
        else
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
        }
        Destroy(player.gameObject);
        if (newPlayer != null)
        {
            newPlayer.transform.parent = playerContainer.transform;
            playersList.Add(newPlayer.GetComponent<Player>());
        } else
        {
            Debug.Log("Player "+ name+ " has been definately killed.");
        }
    }
}
