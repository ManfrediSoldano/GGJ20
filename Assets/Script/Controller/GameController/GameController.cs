using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<PlayerManager> playersList = new List<PlayerManager>();
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
            playersList.Add(player.GetComponent<PlayerManager>());
            numberOfFixers--;
        }

        while (numberOfDestroyers > 0)
        {
            GameObject player = spawnManager.SpawnNewPlayer(PlayerType.DESTROYER);
            player.transform.parent = playerContainer.transform;
            playersList.Add(player.GetComponent<PlayerManager>());
            numberOfDestroyers--;
        }

    }
}
