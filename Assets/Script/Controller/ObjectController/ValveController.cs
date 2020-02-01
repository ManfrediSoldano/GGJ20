using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    public ValveStatus status;
    public WaterController waterController;

    public void Awake()
    {
        waterController = GameObject.Find("WaterController").GetComponent<WaterController>();
    }

    /// <summary>
    /// Change the status of the pipe to the broken one.
     /// Increase the water increase speed.
    /// </summary>
    public void Broke()
    {
        status = ValveStatus.BROKEN;
        waterController.openPipes++;
    }

    /// <summary>
    /// Change the status of the pipe to the working/open/Fixed one.
    /// Reduce the water increase speed.
    /// </summary>
    public void FixedJoint()
    {
        status = ValveStatus.OPEN;
        waterController.openPipes--;
    }


}
