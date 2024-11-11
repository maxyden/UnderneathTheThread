using UnityEngine;
using TMPro;

public class JournalTextReveal : MonoBehaviour
{
    public TextMeshPro textMesh; // Reference to the TextMesh Pro component
    private bool isIlluminated = false; // Track if flashlight is illuminating text

    void Start()
    {
        textMesh.enabled = false; // Start with text hidden
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the flashlight's light collider
        if (other.CompareTag("FlashlightLight")) // Ensure your flashlight light has this tag
        {
            isIlluminated = true;
            textMesh.enabled = true; // Show text
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FlashlightLight"))
        {
            isIlluminated = false;
            textMesh.enabled = false; // Hide text when not illuminated
        }
    }
}
