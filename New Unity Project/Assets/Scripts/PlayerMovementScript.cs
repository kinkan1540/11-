using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public bool allowUpDown;

    public float jumpForce;
    private bool isJumping;

    private Vector3 moveDirection;
    private Rigidbody rb;

    public Animator playerAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {


        if (allowUpDown)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 1).normalized;
        }
        if (Input.GetButtonDown("Jump")&&!isJumping)
        {
            isJumping = true;
            playerAnimator.SetBool("isJumping",true);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        
        if(isJumping)
        {
            rb.AddForce(transform.up * jumpForce);
            isJumping = false;
            playerAnimator.SetBool("isJumping", false);
        }

    }
}
