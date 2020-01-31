using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    //delegates for movement
    public delegate void Move(int mov, int playerNumber);
    public delegate void Jump();
    //Event related to the delegate.
    public static event Move OnMove;
    public static event Jump OnJump;

    private void NotifyNewMove(int mov, int playerNumber)
    {
        if (OnMove != null)
        {
            OnMove(mov, playerNumber);
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

    }


    

}
