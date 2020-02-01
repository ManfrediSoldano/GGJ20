using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    //delegates for movement
    public delegate void Move(int playerNumber, float mov);
    public delegate void Jump(int playerNumber);
    //Event related to the delegate.
    public static event Move OnMove;
    public static event Jump OnJump;

    private void NotifyNewMove(int playerNumber, float mov)
    {
        if (OnMove != null)
        {
            OnMove(playerNumber, mov);
        }
    }

    private void NotifyNewJump(int playerNumber)
    {
        if (OnMove != null)
        {
            OnJump(playerNumber);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NotifyNewMove(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) {
            NotifyNewMove(1, Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("jump") > 0) {
            NotifyNewMove(1, Input.GetAxis("Horizontal"));
        }


    }


    

}
