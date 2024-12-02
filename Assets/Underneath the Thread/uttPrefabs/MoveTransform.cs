using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    // Function to move the transform to a target position and rotation
    public void MoveToLocation(Transform targetTransform)
    {
        // Update position to the target transform's position
        transform.position = targetTransform.position;

        // Update rotation to match the target transform's rotation
        transform.rotation = targetTransform.rotation;
    }
}
