using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem Dust; // Reference to the particle system for dust when moving
    public AudioSource jumpSoundEffect; // Reference to the audio source for jump sound
    public LayerMask jumpableGround; // Layer mask to determine what is considered as jumpable ground

    private Rigidbody2D rb; // Reference to the player's Rigidbody for physics interactions
    private BoxCollider2D coll; // Reference to the player's BoxCollider2D for collisions
    private Animator anim; // Reference to the player's Animator for animations
    private SpriteRenderer sprite; // Reference to the player's SpriteRenderer for sprite manipulations

    private float dirX = 0f; // Variable to store horizontal input
    [SerializeField] private float moveSpeed = 6f; // Speed at which the player moves horizontally
    [SerializeField] private float jumpForce = 12f; // Force applied when the player jumps

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Getting the player's Rigidbody component
        coll = GetComponent<BoxCollider2D>(); // Getting the player's BoxCollider2D component
        sprite = GetComponent<SpriteRenderer>(); // Getting the player's SpriteRenderer component
        anim = GetComponent<Animator>(); // Getting the player's Animator component
    }

    private void Update()
    {
        HandleMovementInput(); // Handling player movement input
        UpdateAnimationState(); // Updating player animation state
    }

    private void HandleMovementInput()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // Getting horizontal input
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // Applying horizontal movement to the Rigidbody

        if (Input.GetButtonDown("Jump") && IsGrounded()) // Checking for jump input and whether the player is grounded
        {
            jumpSoundEffect.Play(); // Playing the jump sound effect
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Applying vertical force for jumping
        }

        if (dirX != 0)
        {
            CreateDust(); // Creating dust particles when moving horizontally
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state = GetMovementState(); // Getting the current movement state

        if (state == MovementState.running)
        {
            sprite.flipX = dirX < 0f; // Flipping the sprite based on the direction of movement
        }

        anim.SetInteger("state", (int)state); // Updating the Animator with the current movement state
    }

    private MovementState GetMovementState()
    {
        if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f) // Checking if the player is jumping or falling
        {
            CreateDust(); // Creating dust particles when jumping or falling
            return rb.velocity.y > 0.1f ? MovementState.jumping : MovementState.falling; // Returning the appropriate movement state
        }

        return dirX != 0 ? MovementState.running : MovementState.idle; // Returning the appropriate movement state based on horizontal input
    }

    private bool IsGrounded()
    {
        // Checking if the player is grounded using a BoxCast to detect ground collisions
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void CreateDust()
    {
        Dust.Play(); // Playing the dust particle system
    }

    // Handle other collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handling other collisions
        // This code was added so that if in the future it was decided to improve or expand the game 
        // or add additional functions, this method could be very easily used and easily modified.
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Handling other trigger zone collisions
        // This code was added so that if in the future it was decided to improve or expand the game 
        // or add additional functions, this method could be very easily used and easily modified.
    }

    private enum MovementState { idle, running, jumping, falling }
    // Enum representing different player movement states
    // This enum was added so that if in the future it was decided to improve or expand the game 
    // or add additional functions related to player movement, 
    // this enum could be very easily used and easily modified.
}






