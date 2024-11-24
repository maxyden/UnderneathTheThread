using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerHead; // Assign the VR headset's transform
    public float distanceFromPlayer = 2f; // Distance in front of the player
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Offset for height adjustment

    void Update()
    {
        if (playerHead != null)
        {
            // Calculate position directly in front of the player
            Vector3 targetPosition = playerHead.position + playerHead.forward * distanceFromPlayer + offset;

            // Update UI position
            transform.position = targetPosition;

            // Rotate UI to face the player
            transform.LookAt(playerHead);

            // Keep UI upright
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
