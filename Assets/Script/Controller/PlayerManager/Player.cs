﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public int playerNumber { get; set; }
    public float velocity;
    public float jumpForce;
    Rigidbody2D rb;
    public Collider2D currentCollider;
    
    // Start is called before the first frame update
    void Awake()
    {
        InputManager.OnMove += Walk;
        InputManager.OnJump += Jump;
        InputManager.OnUse += Use;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

   

    void OnDestroy()
    {
        InputManager.OnMove -= Walk;
        InputManager.OnJump -= Jump;
        InputManager.OnUse -= Use;
    }

    void Walk(int playerNumber, float direction) {
        if (this.playerNumber == playerNumber) {
            rb.velocity = new Vector2 (direction * velocity, rb.velocity.y);
        }
    }

    void Jump(int playerNumber)
    {
        Debug.Log("Received a JUMP request: " + playerNumber + " my player number: " + this.playerNumber);
        if (this.playerNumber == playerNumber && rb.velocity.y == 0)
        {   
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Use(int playerNumber)
    {
        Debug.Log("Received a USE request: " + playerNumber + " my player number: " + this.playerNumber);

        if (this.playerNumber == playerNumber)
        {
            if(currentCollider != null)
            {
                if(currentCollider.gameObject !=null && currentCollider.gameObject.tag != null)
                {

                    if (currentCollider.gameObject.tag == "Object")
                    {
                        currentCollider.gameObject.GetComponent<SceneObjectController>().ActivateObject(this.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentCollider = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCollider = null;
    }

}
