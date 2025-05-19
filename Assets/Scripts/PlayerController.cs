using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 10;
    public float jumpForce = 30;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        //Debug.Log($"Input value: {moveInput}");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else {

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
 }

        if (Input.GetKeyDown(KeyCode.Space))
{ 
        //rb.AddForce(new Vector2(0, jumpForce));
        //mozna to opisac inaczej
        rb.AddForce(Vector2.up * jumpForce);
        }

    }
}
