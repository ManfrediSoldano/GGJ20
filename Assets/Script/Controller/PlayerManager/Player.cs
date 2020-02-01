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
    public Collider2D currentCollider;
    private Animator animator;
    private bool isLookRight = true;
    private AudioController controller;

    // Start is called before the first frame update
    void Awake()
    {
        InputManager.OnMove += Walk;
        InputManager.OnJump += Jump;
        InputManager.OnUse += Use;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
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
            animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
            if (direction > 0 && !isLookRight)
            {
                transform.Rotate(0, 180, 0, Space.Self);
                isLookRight = true;
            }
            else if(direction < 0 && isLookRight)
            {
                transform.Rotate(0, 180, 0, Space.Self);
                isLookRight = false;
            }
        }
    }

    void Jump(int playerNumber)
    {
        Debug.Log("Received a JUMP request: " + playerNumber + " my player number: " + this.playerNumber);
        if (this.playerNumber == playerNumber && (rb.velocity.y < 0.01 && rb.velocity.y > -0.01))
        {   
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
    }

    void Use(int playerNumber)
    {
        Debug.Log("Received a USE request: " + playerNumber + " my player number: " + this.playerNumber);
        
        if (this.playerNumber == playerNumber)
        {
            animator.SetTrigger("Action");
            if (currentCollider != null)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentCollider = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCollider = null;
    }

   

}
