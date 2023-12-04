using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Reference to the player's transform, set in the Unity Editor
    [SerializeField] private Transform player;
    // Update is called once per frame
    private void Update()
    {
        // This creates a simple 2D camera that tracks the player's movements in a side-scrolling game
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
