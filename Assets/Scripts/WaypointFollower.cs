using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Array to hold the waypoints that the object to follow
    public GameObject[] waypoints;

    // Index to keep track of the current waypoint
    private int currentWaypointIndex = 0;

    // Speed at which the object moves between waypoints
    public float speed = 8f;

    // Update is called once per frame
    void Update()
    {
        // Call the MoveToWaypoint method to handle the object's movement logic
        MoveToWaypoint();
    }

    // Method responsible for moving the object towards the current waypoint
    void MoveToWaypoint()
    {
        // Calculate the distance between the object and the current waypoint
        float distance = Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position);
        // Check if the object is close enough to the waypoint
        if (distance < 0.2f)
        {
            // If close, update the waypoint index to move to the next waypoint
            UpdateWaypointIndex();
        }

        // Move the object towards the current waypoint using Lerp for smooth movement
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    // Method to update the waypoint index when the object reaches a waypoint
    void UpdateWaypointIndex()
    {
        // Increment the waypoint index
        currentWaypointIndex++;

        // Check if the index exceeds the number of waypoints, and reset if necessary
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }
}




