using System;
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
    public Animator animator;
    private bool isLookRight = true;
    private AudioController audioController;
    private GameController gameController;
    public PunchColliderController punchCollider;
    private bool locker = false;
    public GameObject xButton;
    // Start is called before the first frame update
    void Awake()
    {
        InputManager.OnMove += Walk;
        InputManager.OnJump += Jump;
        InputManager.OnUse += Use;
        InputManager.OnPunch += Punch;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }



    void OnDestroy()
    {
        InputManager.OnMove -= Walk;
        InputManager.OnJump -= Jump;
        InputManager.OnUse -= Use;
        InputManager.OnPunch -= Punch;

    }

    void Walk(int playerNumber, float direction)
    {
        if (this.playerNumber == playerNumber && !locker)
        {
            rb.velocity = new Vector2(direction * velocity, rb.velocity.y);
            animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
            if (direction > 0 && !isLookRight)
            {
                transform.Rotate(0, 180, 0, Space.Self);
                isLookRight = true;
            }
            else if (direction < 0 && isLookRight)
            {
                transform.Rotate(0, 180, 0, Space.Self);
                isLookRight = false;
            }
        }
    }

    void Jump(int playerNumber)
    {
        Debug.Log("Received a JUMP request: " + playerNumber + " my player number: " + this.playerNumber);
        if (this.playerNumber == playerNumber && (rb.velocity.y < 0.01 && rb.velocity.y > -0.01) && !locker)
        {
            audioController.Jump();
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    void Use(int playerNumber)
    {
        Debug.Log("Received a USE request: " + playerNumber + " my player number: " + this.playerNumber);

        if (this.playerNumber == playerNumber)
        {
            //animator.SetTrigger("Action");
            if (currentCollider != null)
            {
                if (currentCollider.gameObject != null && currentCollider.gameObject.tag != null)
                {
                    if (currentCollider.gameObject.tag == "Object")
                    {
                        Debug.Log("Using an Object: " + currentCollider.gameObject.name + " my player number: " + this.playerNumber);
                        currentCollider.gameObject.GetComponent<SceneObjectController>().ActivateObject(this.gameObject);
                    }
                }
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (collision.gameObject != null && collision.gameObject.tag != null)
            {
                if (collision.gameObject.tag == "Object")
                { 
                    xButton.SetActive(true);
                    currentCollider = collision;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCollider = null;

        xButton.SetActive(false);

    }


    private void Punch(int playerNumber)
    {
        if (this is Fixer && this.playerNumber == playerNumber)
        {
            animator.SetTrigger("Action");
            foreach (Player playerInList in gameController.playersList)
            {
                if (playerInList is Destroyer)
                {
                    Debug.Log("checking " + playerInList.name);
                    if (punchCollider.currentPlayer != null
                        && playerInList == punchCollider.currentPlayer)
                    {
                        locker = true;
                        animator.SetTrigger("Killed");
                        gameController.Kill(playerInList);
                        locker = false;
                        break;
                    }
                }
            }
        }
    }


}
