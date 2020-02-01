using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    int playerNumber;
    public float velocity;
    public float jumpForce;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnMove += Walk;
        InputManager.OnJump += Jump;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        InputManager.OnMove -= Walk;
        InputManager.OnJump -= Jump;
    }

    void Walk(int playerNumber, float direction) {
        if (this.playerNumber == playerNumber) {
            rb.velocity = new Vector2 (direction * velocity, rb.velocity.y);
        }
    }

    void Jump(int playerNumber)
    {
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
