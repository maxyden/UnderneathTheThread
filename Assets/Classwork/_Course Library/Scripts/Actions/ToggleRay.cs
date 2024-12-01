using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects.
/// Should be placed on a ray interactor.
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{
    [Tooltip("Switch even if an object is selected")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool isSwitched = false;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        SwitchInteractors(false);
    }

    public void ToggleRayInteractor()
    {
        // Toggle the ray interactor state
        SwitchInteractors(!isSwitched);
    }

    private bool TouchingObject()
    {
        List<IXRInteractable> targets = new List<IXRInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    private void SwitchInteractors(bool value)
    {
        // Only switch if we're not touching an object or if forceToggle is true
        if (!TouchingObject() || forceToggle || value != isSwitched)
        {
            isSwitched = value;
            rayInteractor.enabled = value;
            directInteractor.enabled = !value;
        }
    }
}
