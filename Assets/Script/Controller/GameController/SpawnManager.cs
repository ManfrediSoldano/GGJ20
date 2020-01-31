using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<SpawnPoint> fixerSpawnPointList = new List<SpawnPoint>();
    public List<SpawnPoint> sharedSpawnPointList = new List<SpawnPoint>();
    public List<SpawnPoint> destroyerSpawnPointList = new List<SpawnPoint>();

    public GameObject fixerPrefab;
    public GameObject destroyerPrefab;

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
        Debug.Log("Spawning a new player. Type: "+type, this);
        SpawnPoint point = GetSpawnPositionCharacter(type);
        if (type == PlayerType.FIXER)
            return (Instantiate(fixerPrefab, point.transform.position, Quaternion.identity));
        else
            return (Instantiate(destroyerPrefab, point.transform.position, Quaternion.identity));

    }

    /// <summary>
    /// Return a spawn position based on the type of the player.
    /// </summary>
    /// <param name="type"> Type of the player. </param>
    public SpawnPoint GetSpawnPositionCharacter(PlayerType type)
    {
        System.Random random = new System.Random();
        int shouldUseShared = random.Next(2);
        bool useShared = false;
        if (sharedSpawnPointList.Count > 0 && shouldUseShared == 1)
            useShared = true;
        if (type == PlayerType.DESTROYER)
        {
            if (sharedSpawnPointList.Count > 0 && destroyerSpawnPointList.Count == 0)
                useShared = true;

            if (useShared)
            {
                int index = random.Next(sharedSpawnPointList.Count);
                return (sharedSpawnPointList[index]);
            }
            else
            {
                int index = random.Next(destroyerSpawnPointList.Count);
                return (destroyerSpawnPointList[index]);
            }
        }
        else
        {
            if (sharedSpawnPointList.Count > 0 && fixerSpawnPointList.Count == 0)
                useShared = true;

            if (useShared)
            {
                int index = random.Next(sharedSpawnPointList.Count);
                return (sharedSpawnPointList[index]);
            }
            else
            {
                int index = random.Next(fixerSpawnPointList.Count);
                return (fixerSpawnPointList[index]);
            }
        }
    }
}
