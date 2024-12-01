using UnityEngine;

public class TimerToggleActive : MonoBehaviour
{
    // Public reference to the GameObject you want to toggle
    public GameObject targetObject;

    // Time interval in seconds to set the active state
    public float timeInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the targetObject is assigned
        if (targetObject != null)
        {
            // Set the active state after the specified interval (only once)
            Invoke("ToggleActive", timeInterval);
        }
        else
        {
            Debug.LogError("Target GameObject is not assigned!");
        }
    }

    // Method to toggle the active state of the target object
    void ToggleActive()
    {
        if (targetObject != null)
        {
            // Toggle the active state (active becomes inactive, and vice versa)
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}