using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnMove += Walk;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        InputManager.OnMove += Walk;
    }

    void Walk(int Direction, int playerNumber) {
        if (this.playerNumber== playerNumber) {

        }
    }

    void MoveRight(int playerNumber)
    {
        if (this.playerNumber == playerNumber)
        {

        }
    }
}
