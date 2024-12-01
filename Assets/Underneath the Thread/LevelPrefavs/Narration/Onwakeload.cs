
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnWake : MonoBehaviour
{
    // Name of the scene you want to load (set this in the Inspector)
    public string sceneName = "YourSceneName";

    // This method is called when the object is initialized and the game wakes up
    void Awake()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}