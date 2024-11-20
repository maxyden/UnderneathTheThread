using UnityEngine;

/// <summary>
/// This script makes it easier to toggle between a new material, and the objects original material.
/// </summary>
public class ChangeKnife : MonoBehaviour
{
    [Tooltip("The material that's switched to.")]
    public Material otherMaterial = null;

    private bool usingOther = false;
    private SkinnedMeshRenderer skinnedmeshRenderer = null;
    private Material originalMaterial = null;

    private void Awake()
    {
        skinnedmeshRenderer = GetComponent<SkinnedMeshRenderer>();
        originalMaterial = skinnedmeshRenderer.material;
    }

    public void SetOtherMaterial()
    {
        usingOther = true;
        skinnedmeshRenderer.material = otherMaterial;
    }

    public void SetOriginalMaterial()
    {
        usingOther = false;
        skinnedmeshRenderer.material = originalMaterial;
    }

    public void ToggleMaterial()
    {
        usingOther = !usingOther;

        if (usingOther)
        {
            skinnedmeshRenderer.material = otherMaterial;
        }
        else
        {
            skinnedmeshRenderer.material = originalMaterial;
        }
    }
}
