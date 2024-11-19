using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransitionScript : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform spawnPoint1; // Spawn Point 1
    public Transform spawnPoint2; // Spawn Point 2
    //public Transform spawnPoint3; // Spawn Point 3
    // Add more spawn points as needed

    [Header("Transition Settings")]
    public float fadeDuration = 1.0f; // Duration of fade in/out
    public float moveDuration = 0.5f; // Duration of the movement

    [Header("UI Fade Overlay")]
    public CanvasGroup fadeCanvasGroup; // UI element for fade effect

    private void Start()
    {
        if (fadeCanvasGroup == null)
        {
            Debug.LogError("FadeCanvasGroup is not assigned. Please set it in the inspector.");
        }
    }

    /// <summary>
    /// Moves the player to Spawn Point 1.
    /// </summary>
    public void MoveToSpawnPoint1()
    {
        StartCoroutine(TransitionToSpawnPoint(spawnPoint1));
    }

    /// <summary>
    /// Moves the player to Spawn Point 2.
    /// </summary>
    public void MoveToSpawnPoint2()
    {
        StartCoroutine(TransitionToSpawnPoint(spawnPoint2));
    }

    /// <summary>
    /// Moves the player to Spawn Point 3.
    /// </summary>
    //public void MoveToSpawnPoint3()
//{
        //StartCoroutine(TransitionToSpawnPoint(spawnPoint3));
    //}

    // Add more methods as needed for additional spawn points.

    private IEnumerator TransitionToSpawnPoint(Transform targetSpawnPoint)
    {
        if (targetSpawnPoint == null)
        {
            Debug.LogError("Target spawn point is not assigned!");
            yield break;
        }

        // Fade out
        yield return Fade(1.0f);

        // Move the player
        yield return SmoothMove(targetSpawnPoint.position);

        // Fade in
        yield return Fade(0.0f);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeCanvasGroup.alpha;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = targetAlpha;
    }

    private IEnumerator SmoothMove(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / moveDuration);
            yield return null;
        }

        transform.position = targetPosition;
    }
}



