using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePad : MonoBehaviour
{


    public Text leftPlayer;
    public Text rightPlayer;

    void Update()
    {
        int counter = 0;

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length >= 18)
            {
               
                counter++;
            }
        }


        if (counter == 1)
        {
            leftPlayer.text = "Connected!";
            rightPlayer.text = "Connect B";
        }
        else if (counter > 1)
        {
            leftPlayer.text = "Connected!";
            rightPlayer.text = "Connected!";
        }
        else
        {
            leftPlayer.text = "Connect A";
            rightPlayer.text = "Connect B";
        }

    }
}
