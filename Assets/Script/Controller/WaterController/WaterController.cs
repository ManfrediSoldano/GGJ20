using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{

    public int openPipes = 0;
    public GameController controller;


    [Range(0.0f, 5f)]
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (openPipes > 0)
        {
            transform.position += new Vector3(0,Time.deltaTime*(openPipes/(10/speed)), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered: "+ other.gameObject.tag);
        if (other.gameObject != null)
        {
            if (other.gameObject.tag != null)
            {
                if (other.gameObject.tag == "Player")
                {
                    controller.RemovePlayer(other.gameObject.GetComponent<Player>());
                }
            }
        }
    }
}
