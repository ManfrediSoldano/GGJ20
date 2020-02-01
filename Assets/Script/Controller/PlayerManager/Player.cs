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
        InputManager.OnJump += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        InputManager.OnMove -= Walk;
        InputManager.OnJump -= Jump;
    }

    void Walk(int playerNumber, float Direction) {
        if (this.playerNumber == playerNumber) {

        }
    }

    void Jump(int playerNumber)
    {
        if (this.playerNumber == playerNumber)
        {

        }
    }
}
