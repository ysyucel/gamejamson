using UnityEngine;
using System.Collections;

public class EarthquakeMovement : MonoBehaviour
{
    // Parameters
    public float maxShakeDistance = 0.1f;
    public float shakeSpeed = 1f;

    // Internal variables
    private Vector3 initialPosition;

    void Start()
    {
        // Store initial position
        initialPosition = transform.position;

        // Start shaking coroutine
        StartCoroutine(Shake());
    }

     IEnumerator Shake()
    {
        while (true)
        {
            // Calculate random displacement within specified distance
            Vector3 randomDisplacement = Random.insideUnitSphere * maxShakeDistance;
            randomDisplacement= new Vector3(randomDisplacement.x, 0f, randomDisplacement.z);  
            // Apply displacement to building object
            transform.position = initialPosition + randomDisplacement;

            // Wait for a short time before applying next displacement
            yield return new WaitForSeconds(1f / shakeSpeed);
        }
    }
}