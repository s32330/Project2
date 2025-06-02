using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 10;
    public float jumpForce = 30;
    public Rigidbody2D rb;
    public GroundChecker groundChecker;
    public PlayerHealth health;
    InventoryManager Inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health= GetComponent<PlayerHealth>();

        //do inventory
       Inventory=GameObject.Find("Canvas").GetComponent<InventoryManager>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //zeby kursor byl niewidoczny normalnie
        if (Inventory.IsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }

        if (health.isDead) return;

        float moveInput = Input.GetAxis("Horizontal");
        //Debug.Log($"Input value: {moveInput}");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else {

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
 }

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
{ 
        //rb.AddForce(new Vector2(0, jumpForce));
        //mozna to opisac inaczej
        rb.AddForce(Vector2.up * jumpForce);
        }

      
    }

   
}
