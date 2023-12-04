using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to the player's Rigidbody for physics interactions
    private Animator anim; // Reference to the player's Animator for animations

    [SerializeField] private AudioSource deathSoundEffect; // Sound effect played on player death
    [SerializeField] private float scaleOnDeath = 0.2f; // Scale factor applied when player dies, can be adjusted

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Getting the player's Rigidbody component
        anim = GetComponent<Animator>(); // Getting the player's Animator component
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsTrap(collision)) // Checking if the collided object is identified as a trap
        {
            HandleTrapCollision(); // Executing actions related to player encountering a trap
        }
    }

    bool IsTrap(Collision2D collision)
    {
        return collision.gameObject.CompareTag("Trap"); // Comparing the tag of the collided object to identify if it's a trap
    }

    void HandleTrapCollision()
    {
        PlayDeathSound(); // Playing the assigned sound effect for player death
        ScalePlayerOnDeath(); // Scaling down the player's GameObject when encountering a trap
        StopPlayerMovement(); // Stopping the player's movement by resetting velocity to zero
        DisableGravity(); // Disabling gravity to prevent additional physics effects
        FreezePlayer(); // Freezing the player in place by setting the Rigidbody to Static
        TriggerDeathAnimation(); // Triggering the death animation in the Animator component
        RestartLevelAfterDelay(3f); // Restarting the level after a specified delay
    }

    void PlayDeathSound()
    {
        deathSoundEffect.Play(); // Playing the assigned sound effect for player death
    }

    void ScalePlayerOnDeath()
    {
        // Scaling down the player's GameObject when encountering a trap,
        // giving a visual indication of the player's demise. The scale factor
        // is controlled by the 'scaleOnDeath' variable, which can be adjusted
        // in the Unity Editor.
        transform.localScale = new Vector3(scaleOnDeath, scaleOnDeath, 1f);
    }

    void StopPlayerMovement()
    {
        rb.velocity = Vector2.zero; // Stopping the player's movement by resetting velocity to zero
    }

    void DisableGravity()
    {
        rb.gravityScale = 0f; // Disabling gravity to prevent additional physics effects
    }

    void FreezePlayer()
    {
        rb.bodyType = RigidbodyType2D.Static; // Freezing the player in place by setting the Rigidbody to Static
    }

    void TriggerDeathAnimation()
    {
        anim.SetTrigger("death"); // Triggering the death animation in the Animator component
    }

    void RestartLevelAfterDelay(float delay)
    {
        Invoke("RestartLevel", delay); // Restarting the level after a specified delay
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restarting the current level
    }
}






