using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator playerAnim;
    private BoxCollider2D boxCollider;

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private LayerMask groundLayer;
    private string horizontalAxis = "Horizontal";
    private string jump = "Jump";
    private string runAnimationParam = "run";
    private string groundedAnimationParam = "grounded";

    private void Awake()
    {
        // Grab reference
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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

        playerAnim.SetBool(groundedAnimationParam, isGrounded());

        transform.position = tempPos;
    }

    void Jump()
    {
        if (Input.GetButtonDown(jump))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
            playerAnim.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
