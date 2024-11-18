using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKnifeMaterial : MonoBehaviour
{
    [Tooltip("The material that's switched to.")]
    public Material otherMaterial = null;

    private bool usingOther = false;
    private SkinnedMeshRenderer skinnedMeshRenderer = null;
    private Material originalMaterial = null;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        originalMaterial = skinnedMeshRenderer.material;
    }

    public void SetOtherMaterial()
    {
        usingOther = true;
        skinnedMeshRenderer.material = otherMaterial;
    }

    public void SetOriginalMaterial()
    {
        usingOther = false;
        skinnedMeshRenderer.material = originalMaterial;
    }

    public void ToggleMaterial()
    {
        usingOther = !usingOther;

        if (usingOther)
        {
            skinnedMeshRenderer.material = otherMaterial;
        }
        else
        {
            skinnedMeshRenderer.material = originalMaterial;
        }
    }
}

