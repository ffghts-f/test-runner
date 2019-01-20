using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //Indicates how high the player will jump
    public float jumpForce = 6f;


    //Used for adding the jump force to the player
    private Rigidbody2D playerRB;

    //Used for playing Animations (f.e. while Jumping)
    private Animator playerAnimator;

    //Used for determining if the Player should be able to jump
    private bool bCanJump = true;

    // Use this for initialization
    void Start()
    {
        //Set the Rigidbody2D variable to the players Rigidbody
        playerRB = GetComponent<Rigidbody2D>();
        //Set the Animator variable to the players Animator
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump when f is pressed
        if (Input.GetKey("f"))
        {
            Jump();
        }

#if UNITY_ANDROID
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
#endif
    }

    //Jump method
    public void Jump()
    {
        //Check if player is on the ground and therefore able to jump
        if (bCanJump)
        {
            //Set bCanJump false so the player can't jump when already in the air
            bCanJump = false;
            //Add upwards velocity to the player to make him jump
            playerRB.velocity = new Vector2(0f, jumpForce);
            //Start the Jump Animation 
            playerAnimator.Play("PlayerJump");
        }
    }

    void OnCollisionEnter2D(Collision2D currentCollision)
    {
        //Set bCanJump true when colliding with the Ground, so the player is able to jump again
        if (currentCollision.collider.CompareTag("Ground") && GameManager.GameOver == false)
        {
            bCanJump = true;
            //Restart the Run Animation when hitting the Ground
            playerAnimator.Play("PlayerRunAnimation");
        }

        if (currentCollision.collider.CompareTag("Obstacle") && GameManager.GameOver == false)
        {
            //Stops Map Movement and makes player unable to jump
            GameManager.GameOver = true;
            //Starts playing the Player Dead Animation
            playerAnimator.Play("PlayerDead");
            //Stops the animation after 2.5 seconds so the Animation plays till the end but doesn't restart
            Invoke("StopAnimation", 2.5f);
        }
    }

    public void StopAnimation()
    {
        //Disables the Animator so the Animation stops
        playerAnimator.enabled = false;
    }

}
