using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [Range(0, 10)]
    [TooltipAttribute("This variable will set the speed of the movement")]
    public float movementSpeed = 5f;

    public Rigidbody2D rb;      //referencing the rigidbody2d that is used for the player
    public Animator animator;

    Vector2 movement;       //storing the movement input
                            // Update is called once per frame
    public new void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");       //Updating the movement on the Horizontal axis
        movement.y = Input.GetAxisRaw("Vertical");      //Updating the movement on the Vertical axis
        animator.SetFloat("Horizontal", movement.x);        //Changing the float value in the animator based on input
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);      //Setting speed value with a squared magnitude for better optimization
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);      //applying the movement to the rigidbody
    }
}
