using UnityEngine;
using UnityEngine.XR;

public class FootstepAudioManager : MonoBehaviour
{
    public AudioSource footstepAudioSource;   // Reference to the AudioSource for footsteps
    public float movementThreshold = 0.1f;    // The minimum movement distance to play footstep sounds
    public float stepInterval = 0.5f;         // Time between each footstep sound

    private Vector3 lastPosition;
    private float stepTimer;

    private XRNode leftControllerNode = XRNode.LeftHand;
    private XRNode rightControllerNode = XRNode.RightHand;

    private InputDevice leftController;
    private InputDevice rightController;

    void Start()
    {
        // Initialize lastPosition to current position
        lastPosition = transform.position;
        stepTimer = stepInterval;

        // Get input devices for controllers
        leftController = InputDevices.GetDeviceAtXRNode(leftControllerNode);
        rightController = InputDevices.GetDeviceAtXRNode(rightControllerNode);
    }

    void Update()
    {
        // Check if the controllers have moved by getting the positions
        Vector3 leftControllerPosition = GetControllerPosition(leftController);
        Vector3 rightControllerPosition = GetControllerPosition(rightController);

        // Check if either controller has moved
        if (Vector3.Distance(lastPosition, transform.position) > movementThreshold ||
            Vector3.Distance(leftControllerPosition, Vector3.zero) > movementThreshold ||
            Vector3.Distance(rightControllerPosition, Vector3.zero) > movementThreshold)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                // Play the footstep sound
                PlayFootstepSound();

                // Reset the timer
                stepTimer = stepInterval;
            }
        }

        // Update the last position to current position for next frame
        lastPosition = transform.position;
    }

    private Vector3 GetControllerPosition(InputDevice controller)
    {
        if (controller.isValid)
        {
            Vector3 position;
            if (controller.TryGetFeatureValue(CommonUsages.devicePosition, out position))
            {
                return position;
            }
        }
        return Vector3.zero;
    }

    private void PlayFootstepSound()
    {
        // Play the footstep sound if it's not already playing
        if (!footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Play();
        }
    }
}
