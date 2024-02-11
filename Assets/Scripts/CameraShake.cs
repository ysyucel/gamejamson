using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Parameters
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 0.5f;

    // Internal variables
    private Vector3 originalPosition;

    void Start()
    {
        // Store the camera's original position
        originalPosition = transform.localPosition;
        //Shake();
    }

    public void Shake()
    {
        // Start coroutine to shake the camera
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Calculate a random shake amount
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;

            // Apply the shake to the camera's position
            transform.localPosition = originalPosition + randomOffset;

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Reset the camera's position after the shake is finished
        transform.localPosition = originalPosition;
    }
}