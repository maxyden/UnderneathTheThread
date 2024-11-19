using UnityEngine;
using UnityEngine.Events;

public class CallCounter : MonoBehaviour
{
    // UnityEvent to be called after the function has been called 3 times
    [SerializeField]
    private UnityEvent onThreeCalls;

    private int callCount = 0;

    // Function to be called by the UnityEvent
    public void CallFunction()
    {
        callCount++;
        Debug.Log($"Function called {callCount} time(s).");

        // Check if the function has been called 3 times
        if (callCount >= 3)
        {
            onThreeCalls.Invoke(); // Call the UnityEvent
            // ResetCounter(); // Reset the counter if needed
        }
    }

    // Optional: Reset the counter
    // private void ResetCounter()
    // {
    //     callCount = 0;
    //     Debug.Log("Counter reset.");
    // }
}
