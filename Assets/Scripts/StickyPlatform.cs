using System.Collections;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Flag indicating whether the platform is active
    [SerializeField] private bool isPlatformActive = true;

    // Reference to the particle system for moving particles
    [SerializeField] private ParticleSystem movingParticles;

    // Variable to store the last X position of the platform
    private float lastXPosition;

    // Called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Apply parent to the collided object and start moving particles
        ApplyParentOnCollision(collision);
        StartMovingParticles();
    }

    // Called when another collider exits the trigger zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Remove parent from the collided object and stop moving particles
        RemoveParentForCollision(collision);
        StopMovingParticles();
    }

    // Method to apply parent to the collided object
    private void ApplyParentOnCollision(Collider2D collision)
    {
        // Check if the collided object is the player
        if (IsPlayer(collision))
        {
            // Set the parent for the player
            SetParentForCollision(collision);
        }
    }

    // Method to remove parent from the collided object
    private void RemoveParentForCollision(Collider2D collision)
    {
        // Check if the collided object is the player and the platform is active
        if (IsPlayer(collision) && isPlatformActive)
        {
            // Remove parent with a delay
            StartCoroutine(RemoveParentForCollisionDelayed(collision));
        }
    }

    // Coroutine to remove parent with a delay
    private IEnumerator RemoveParentForCollisionDelayed(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        RemoveParentForCollisionImmediate(collision);
    }

    // Method to remove parent immediately
    private void RemoveParentForCollisionImmediate(Collider2D collision)
    {
        // Log information about the player no longer sticking to the platform
        Debug.Log($"Player {collision.gameObject.name} is no longer sticking to platform {gameObject.name}");
        // Remove the parent relationship
        collision.gameObject.transform.SetParent(null);
    }

    // Method to check if the collided object is the player
    private bool IsPlayer(Collider2D collision)
    {
        return collision.gameObject.name == "Player";
    }

    // Method to set parent for the collided object
    private void SetParentForCollision(Collider2D collision)
    {
        // Log information about the player now sticking to the platform
        Debug.Log($"Player {collision.gameObject.name} is now sticking to platform {gameObject.name}");
        // Set the parent relationship
        collision.gameObject.transform.SetParent(transform);
    }

    // Method to start the moving particles
    private void StartMovingParticles()
    {
        // Check if the particle system is assigned
        if (movingParticles != null)
        {
            // Reset the local position and store the last X position
            movingParticles.transform.localPosition = Vector3.zero;
            lastXPosition = transform.position.x;
            // Play the particle system
            movingParticles.Play();
        }
    }

    // Method to stop the moving particles
    private void StopMovingParticles()
    {
        // Check if the particle system is assigned
        if (movingParticles != null)
        {
            // Stop the particle system
            movingParticles.Stop();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Update the particles' movement
        UpdateParticles();
    }

    // Method to update the particles' movement
    private void UpdateParticles()
    {
        // Check if the particle system is assigned and the platform is active
        if (movingParticles != null && isPlatformActive)
        {
            // Determine the direction based on the change in X position
            float direction = Mathf.Sign(transform.position.x - lastXPosition);
            // Move the particles in the determined direction over time
            movingParticles.transform.Translate(Vector3.right * direction * Time.deltaTime);
            // Update the last X position
            lastXPosition = transform.position.x;
        }
    }
}


















