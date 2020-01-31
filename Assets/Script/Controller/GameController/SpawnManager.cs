using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<PlayerManager> characters = new List<PlayerManager>();
    public GameObject fixerPrefab;
    public GameObject destroyerPrefab;

    public void SpawnCharacter(PlayerType type)
    {
        if (type == PlayerType.DESTROYER)
        {

        } else 
        {

        }
    }
}
