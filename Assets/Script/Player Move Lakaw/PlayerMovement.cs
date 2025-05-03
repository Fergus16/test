using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControles controles;
    float direction = 0;
    public float speed = 400;
    public bool isFacingRight = true;

    //--------------------Jump--------------------------------

    public float jumpForce = 5;
    bool isGrounded;

    int numberOfJumps = 0;
    public Transform groundCheck;//e check niya if ang paa ba sa player kay naa na sa lupa
    public LayerMask groundLayer;//para mag inter ac ang player and ground

    //-------------------------------------------------------

    public Rigidbody2D playerRB;
    public Animator animator;

    private void Awake()
    {
        controles = new PlayerControles();
        controles.Enable();
                                    //ctx checker
        controles.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controles.Land.Jump.performed += ctx => Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerRB != null) // Check if the Rigidbody2D has not been destroyed
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            animator.SetBool("isGrounded", isGrounded);

            playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(direction));

            // Flip the player if necessary
            if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
                Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (playerRB != null) // Check if the Rigidbody2D has not been destroyed
        {
            if (isGrounded)
            {
                numberOfJumps = 0;
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
                AudioManager.instance.Play("FirstJump");
            }
            else
            {
                if (numberOfJumps == 1)
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                    numberOfJumps++;
                    AudioManager.instance.Play("SecondJump");
                }
            }
        }
    }
}
