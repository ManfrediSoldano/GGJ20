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
        Debug.Log("Trying to send a push notification for a new Jump.");
        if (OnJump != null)
        {
            Debug.Log("Sending push notification for a new Jump.");
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
        if (Input.GetAxis("Horizontal") < -0.2f || Input.GetAxis("Horizontal") > 0.2f) {
            NotifyNewMove(1, Input.GetAxis("Horizontal"));
        }

        if (Input.GetButtonDown("JumpJoystick1")) {
            Debug.Log("jump pressed");
            NotifyNewJump(1);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            NotifyUse(1);
        }


        //player 2
        if (Input.GetAxis("Joy2Horizontal") > 0.2f || Input.GetAxis("Joy2Horizontal") < -0.2f)
        {
            NotifyNewMove(2, Input.GetAxis("Joy2Horizontal"));
        }

        if (Input.GetButtonDown("Joy2A"))
        {
            Debug.Log("jump pressed 2");
            NotifyNewJump(2);
        }

        if (Input.GetButtonDown("Joy2X"))
        {
            NotifyUse(2);
        }

    }


    

}
