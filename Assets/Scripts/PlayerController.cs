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
    private SpriteRenderer spriteRenderer;
    private Vector3 input;
    private PlayerAnimator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<PlayerAnimator>();
        rb = GetComponent<Rigidbody2D>();
        health= GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //do inventory
        Inventory =GameObject.Find("Canvas").GetComponent<InventoryManager>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (health.isDead) return;


        Move();

        CursorController();
    }

    public void CursorController() {
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
    }
        

    public void Move() {


        float moveInput = Input.GetAxis("Horizontal");
        
        float inputX = moveInput; //nowo dodane
        float inputY = Input.GetAxis("Vertical"); //nowo dodane

        input = new Vector3(inputX, inputY, 0);

        Flip(moveInput);

        /*if (Input.GetKey(KeyCode.S))
        {
            _animator.Slide();
        }*/


        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else
        {

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            //rb.AddForce(new Vector2(0, jumpForce));
            //mozna to opisac inaczej
            rb.AddForce(Vector2.up * jumpForce);
        }
    }


    public void Flip(float moveInput)
    {
        if (moveInput > 0)
        {
           spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public bool IsMoving()
    {
        
        return input.x != 0;
    }

}
