using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, SceneObjectController
{
    public GameObject connectedPortal;

    public GameObject audioManager;

    public void Awake()
    {
        audioManager = GameObject.Find("AudioManager");
    }

    public void ActivateObject(GameObject player)
    {
        ActivatePortal(player);
    }


    /// <summary>
    /// Activate the portal in order to move a player from a portal to another one.
    /// </summary>
    /// <param name="player">The player that needs to be moved.</param>
    public void ActivatePortal(GameObject player)
    {
        player.GetComponent<Player>().animator.SetTrigger("DoorAction");
        audioManager.GetComponent<AudioController>().Door();
        StartCoroutine(MoveToPortal(player));
    }

    public IEnumerator MoveToPortal(GameObject player)
    {
        yield return new WaitForSeconds(0.2f);
        player.gameObject.transform.position = connectedPortal.transform.position;
    }
}
