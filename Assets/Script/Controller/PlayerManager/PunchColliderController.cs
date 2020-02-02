using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchColliderController : MonoBehaviour
{
    public Player currentPlayer;
    public GameObject bButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject != null && collision.gameObject.tag != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                currentPlayer = collision.gameObject.GetComponent<Player>();
                bButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null && collision.gameObject.tag != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                currentPlayer = null;
                bButton.SetActive(false);
            }
        }
    }
}
