using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject connectedPortal;

    /// <summary>
    /// Activate the portal in order to move a player from a portal to another one.
    /// </summary>
    /// <param name="player">The player that needs to be moved.</param>
    public void ActivatePortal(GameObject player)
    {
        player.gameObject.transform.position = connectedPortal.transform.position;
    }
}
