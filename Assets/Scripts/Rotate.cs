using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Speed at which the object rotates, editable in the Unity Editor
    [SerializeField]
    private float rotationSpeed = 3.2f;

    // Called once per frame
    private void Update()
    {
        // Call the RotateObject method to handle rotation
        RotateObject();
    }

    // Rotates the object based on the set speed
    private void RotateObject()
    {
        // Calculate the amount of rotation for this frame
        float rotationAmount = 360 * rotationSpeed * Time.deltaTime;

        // Rotate the object around its z-axis by the calculated amount
        transform.Rotate(0, 0, rotationAmount);
    }
}

