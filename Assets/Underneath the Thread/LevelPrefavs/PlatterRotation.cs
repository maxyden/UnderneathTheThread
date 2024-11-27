using UnityEngine;

public class PlatterRotation : MonoBehaviour
{
    // Rotation speed, you can adjust this from the inspector
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the platter around its Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
