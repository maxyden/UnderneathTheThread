using UnityEngine;
using TMPro;

public class FlashlightRaycast : MonoBehaviour
{
    public Light flashlight; // Reference to the flashlight light component
    public float flashlightRange = 10f; // Adjust range as needed
    private bool flashlightOn = false; // Tracks if the flashlight is on or off

    void Update()
    {
        // Check if the flashlight is active
        if (flashlight.enabled)
        {
            flashlightOn = true;
            CastRay();
        }
        else
        {
            flashlightOn = false;
            HideAllJournalText();
        }
    }

    void CastRay()
    {
        // Cast a ray straight from the flashlight's position forward
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, flashlightRange))
        {
            // Check if the raycast hits an object tagged "JournalText"
            if (hit.collider.CompareTag("JournalText"))
            {
                TextMeshPro text = hit.collider.GetComponent<TextMeshPro>();
                if (text != null)
                {
                    text.enabled = true; // Show text when flashlight illuminates it
                }
            }
        }
    }

    void HideAllJournalText()
    {
        // Find all objects tagged as "JournalText" and disable the TextMeshPro components
        GameObject[] journalTexts = GameObject.FindGameObjectsWithTag("JournalText");
        foreach (GameObject textObj in journalTexts)
        {
            TextMeshPro text = textObj.GetComponent<TextMeshPro>();
            if (text != null)
            {
                text.enabled = false; // Hide text when flashlight is off or not illuminating it
            }
        }
    }
}
