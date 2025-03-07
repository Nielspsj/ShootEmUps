using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//vTest 1: Movement
//vTest 2: Rigibody gravity
//vTest 3: Ground checker
//vTest 4: Jump
//vTest 5: Flip sprite to direction
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2D;
    private float speed = 8f;
    private float jumpPower = 16f;
    private float horizontal;
    private bool isFacingRight = true;

    private void Awake()
    {
        //Grab a reference before we start doing anything.
        rb2D = GetComponent<Rigidbody2D>();
    }
  
    // Update is called once per frame
    void Update()
    {
        //Store horizontal input (-1 is left, 1 is right).
        horizontal = Input.GetAxisRaw("Horizontal");
        //Jump but check if we are on the ground first.
        if (Input.GetButtonDown("Jump") && isGrounded() == true)
        {
            //Debug.Log("jumped");
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
        }
        //Faster drop after jump.
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
        
        //Debug.Log("ground: " + isGrounded());
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        //Physics movement should be in FixedUpdate
        rb2D.velocity = new Vector2(horizontal * speed, rb2D.velocity.y);
    }

    //A method that is a bool.
    //We can then store the result in the bool/method instead of creating a separate bool.
    private bool isGrounded()
    {
        //using the return keyword we can store the result in the bool/method.
        //OverlapCircle checks around the groundcheck for the ground layer.
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Flip the scale instead of the sprite.
    //Just in case there are lots of sprites that also should be flipped.
    private void FlipPlayer()
    {        
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }        
    }
}
