using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator playerAnim;

    [SerializeField]
    private float movementSpeed = 10f;
    private string horizontalAxis = "Horizontal";
    private string jump = "Jump";
    private string runAnimationParam = "run";
    private string groundedAnimationParam = "grounded";
    private bool grounded;

    private void Awake()
    {
        // Grab reference
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        float h = Input.GetAxisRaw(horizontalAxis);

        Vector2 tempPos = transform.position;

        if (h > 0)
        {
            tempPos.x += movementSpeed * Time.deltaTime;
            sr.flipX = false; // Flip Player to right side

            playerAnim.SetBool(runAnimationParam, true);
        }
        else if (h < 0)
        {
            tempPos.x -= movementSpeed * Time.deltaTime;
            sr.flipX = true; // Flip Player to left side
            playerAnim.SetBool(runAnimationParam, true);
        }
        else
        {
            playerAnim.SetBool(runAnimationParam, false);
        }

        playerAnim.SetBool(groundedAnimationParam, grounded);

        transform.position = tempPos;
    }

    void Jump()
    {
        if (Input.GetButtonDown(jump))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
            playerAnim.SetTrigger("jump");
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
