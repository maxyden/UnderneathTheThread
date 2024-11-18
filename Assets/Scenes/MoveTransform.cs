using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    // Function to move the transform to a target position
    public void MoveToLocation(Transform targetTransform)
    {
        // You can modify this to use a smooth movement or instant
        transform.position = targetTransform.position;
    }
}