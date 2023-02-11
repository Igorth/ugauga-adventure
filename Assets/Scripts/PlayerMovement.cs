using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField]
    private float movementSpeed = 3f;
    private string horizontalAxis = "Horizontal";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(0,14,0);
        }
    }

    void Moviment()
    {
        float h = Input.GetAxisRaw(horizontalAxis);

        Vector2 tempPos = transform.position;

        if (h > 0)
        {
            tempPos.x += movementSpeed * Time.deltaTime;

            sr.flipX = false;
        }
        else if (h < 0)
        {
            tempPos.x -= movementSpeed * Time.deltaTime;

            sr.flipX = true;
        }
    }
}
