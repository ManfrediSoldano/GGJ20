using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    //delegates for movement
    public delegate void Move(int playerNumber, float mov);
    public delegate void Jump(int playerNumber);
    public delegate void Use(int playerNumber);
    //Event related to the delegate.
    public static event Move OnMove;
    public static event Jump OnJump;
    public static event Use OnUse;

    private void NotifyNewMove(int playerNumber, float mov)
    {
        if (OnMove != null)
        {
            OnMove(playerNumber, mov);
        }
    }

    private void NotifyNewJump(int playerNumber)
    {
        if (OnJump != null)
        {
            OnJump(playerNumber);
        }
    }

    private void NotifyUse(int playerNumber)
    {
        if (OnUse != null)
        {
            OnUse(playerNumber);
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
        //player 1
        if (Input.GetAxis("Horizontal") != 0) {
            NotifyNewMove(1, Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("jump") > 0) {
            NotifyNewMove(1, Input.GetAxis("jump"));
        }

        if (Input.GetAxis("Fire3") > 0)
        {
            NotifyNewMove(1, Input.GetAxis("Fire3"));
        }
        //player 2
        if (Input.GetAxis("Joy2Horizontal") > 0)
        {
            NotifyNewMove(2, Input.GetAxis("Joy2Horizontal"));
        }

        if (Input.GetAxis("Joy2A") > 0)
        {
            NotifyNewMove(2, Input.GetAxis("Joy2A"));
        }

        if (Input.GetAxis("Joy2X") > 0)
        {
            NotifyNewMove(2, Input.GetAxis("Joy2X"));
        }

    }


    

}
