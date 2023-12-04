// Import necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class named ItemCollector inheriting from MonoBehaviour
public class ItemCollector : MonoBehaviour
{
    // It is a private variable to store the count of collected strawberries
    private int strawberries = 0;

    // SerializeField allows private variables to be exposed in the Unity Editor
    // Text variable to reference the UI Text displaying the strawberry count
    [SerializeField] private Text strawberriesText;

    // SerializeField for the AudioSource component responsible for the collection sound effect
    [SerializeField] private AudioSource collectionSoundEffect;

    // This method is automatically called when another collider enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the tag "Strawberry"
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            // Play the sound effect associated with strawberry collection
            collectionSoundEffect.Play();

            // Destroy the GameObject representing the collected strawberry
            Destroy(collision.gameObject);

            // Increment the count of collected strawberries
            strawberries++;

            // Update the UI Text to display the updated strawberry count
            strawberriesText.text = "Strawberries: " + strawberries;
        }
    }
}






