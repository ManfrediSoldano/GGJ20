using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public int playerNumber { get; set; }
    public float velocity;
    public float jumpForce;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        InputManager.OnMove += Walk;
        InputManager.OnJump += Jump;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

   

    void OnDestroy()
    {
        InputManager.OnMove -= Walk;
        InputManager.OnJump -= Jump;
    }

    void Walk(int playerNumber, float direction) {
        Debug.Log("Received a walk request: "+playerNumber+" my player number: "+this.playerNumber);
        if (this.playerNumber == playerNumber) {
            rb.velocity = new Vector2 (direction * velocity, rb.velocity.y);
        }
    }

    void Jump(int playerNumber)
    {
        Debug.Log("Received a JUMP request: " + playerNumber + " my player number: " + this.playerNumber);
        if (this.playerNumber == playerNumber)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Use(int playerNumber)
    {
        if (this.playerNumber == playerNumber)
        {
            
        }
    }

}
