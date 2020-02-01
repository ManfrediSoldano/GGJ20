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
            player.transform.parent = playerContainer.transform;
            playersList.Add(player.GetComponent<Player>());
            numberOfFixers--;
        }

        while (numberOfDestroyers > 0)
        {
            GameObject player = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
            player.transform.parent = playerContainer.transform;
            playersList.Add(player.GetComponent<Player>());
            numberOfDestroyers--;
        }

    }

    internal void RemovePlayer(Player player)
    {
        playersList.Remove(player);
        GameObject newPlayer;
        if (player is Fixer){
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.FIXER);
        } else
        {
            newPlayer = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
        }
        Destroy(player);
        newPlayer.transform.parent = playerContainer.transform;
        playersList.Add(newPlayer.GetComponent<Player>());
    }
}
