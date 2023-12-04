using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    // Reference to the audio source for the success sound
    private AudioSource successSound;

    // Flag to track whether the level has been cleared
    private bool levelCleared = false;

    // Called when the script is first loaded
    private void Start()
    {
        // Initialize the successSound variable with the AudioSource component attached to the same GameObject
        successSound = GetComponent<AudioSource>();
    }

    // Called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        // Check if the colliding object is the player and the level hasn't been cleared yet
        if (playerCollider.gameObject.name == "Player" && !levelCleared)
        {
            // Play the success sound
            successSound.Play();

            // Set the levelCleared flag to true to prevent multiple triggers
            levelCleared = true;

            // Invoke the LoadNextLevel method after a delay of 3.1 seconds
            Invoke("LoadNextLevel", 3.1f);
        }
    }

    // Loads the next level in the build order
    private void LoadNextLevel()
    {
        // Get the index of the current scene and load the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

