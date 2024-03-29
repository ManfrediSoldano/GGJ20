﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<SpawnPoint> fixerSpawnPointList = new List<SpawnPoint>();
    public List<SpawnPoint> sharedSpawnPointList = new List<SpawnPoint>();
    public List<SpawnPoint> destroyerSpawnPointList = new List<SpawnPoint>();

    public GameObject fixerPrefab;
    public GameObject destroyerPrefab;

    private int seedHelper = 0;

    private void Awake()
    {
        //Popolate the SpawnPoint Lists
        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            SpawnPoint point = spawnPoint.GetComponent<SpawnPoint>();
            if (point.type == SpawnPointType.FIXER)
                fixerSpawnPointList.Add(point);
            else if (point.type == SpawnPointType.DESTROYER)
                destroyerSpawnPointList.Add(point);
            else if (point.type == SpawnPointType.SHARED)
                sharedSpawnPointList.Add(point);
        }
    }

    /// <summary>
    /// Spawn a new player based from the prefab.
    /// </summary>
    /// <param name="type"></param>
    public GameObject SpawnNewPlayer(PlayerType type)
    {
        SpawnPoint point = GetSpawnPositionCharacter(type);
        if (point != null)
        {
            if (type == PlayerType.FIXER)
                return (Instantiate(fixerPrefab, point.transform.position, Quaternion.identity));
            else
                return (Instantiate(destroyerPrefab, point.transform.position, Quaternion.identity));
        } else
        {
            return null;
        }
    }

    /// <summary>
    /// Return a spawn position based on the type of the player.
    /// </summary>
    /// <param name="type"> Type of the player. </param>
    public SpawnPoint GetSpawnPositionCharacter(PlayerType type)
    {
        
        Random.InitState(System.DateTime.Now.Millisecond + seedHelper);
        seedHelper++;
        int shouldUseShared = Random.Range(0, 2);

        bool useShared = false;
        if (sharedSpawnPointList.Count > 0 && shouldUseShared == 1)
            useShared = true;

        if (type == PlayerType.DESTROYER)
        {
            if (sharedSpawnPointList.Count > 0 && destroyerSpawnPointList.Count == 0)
                useShared = true;
            if (sharedSpawnPointList.Count == 0 && destroyerSpawnPointList.Count == 0)
                return null;
            if (useShared)
            {
                int index = Random.Range(0, sharedSpawnPointList.Count);
                return (sharedSpawnPointList[index]);
            }
            else
            {
                int index = Random.Range(0, destroyerSpawnPointList.Count);
                return (destroyerSpawnPointList[index]);
            }
        }
        else
        {
            if (sharedSpawnPointList.Count > 0 && fixerSpawnPointList.Count == 0)
                useShared = true;
            if (sharedSpawnPointList.Count == 0 && fixerSpawnPointList.Count == 0)
                return null;
            if (useShared)
            {
                int index = Random.Range(0, sharedSpawnPointList.Count);
                return (sharedSpawnPointList[index]);
            }
            else
            {
                int index = Random.Range(0, fixerSpawnPointList.Count);
                return (fixerSpawnPointList[index]);
            }
        }
    }

    /// <summary>
    /// Remove the spawn point from the list of available spawn positions.
    /// </summary>
    /// <param name="point"></param>
    public void RemoveSpawnPoint(SpawnPoint point)
    {
        if (point.type == SpawnPointType.DESTROYER)
        {
            destroyerSpawnPointList.Remove(point);
        }
        else if (point.type == SpawnPointType.SHARED)
        {
            sharedSpawnPointList.Remove(point);
        }
        else if (point.type == SpawnPointType.FIXER)
        {
            fixerSpawnPointList.Remove(point);
        }
    }
}
