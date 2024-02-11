using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShakeObject : MonoBehaviour
{
    public float shakeForce = 10f;
    public float shakeDuration = 1f;

    void Start()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("shell");
        // Shake the object when the game starts
        Shake();
    }

    void Shake()
    {
        // Create a temporary Rigidbody
        Rigidbody tempRb = gameObject.AddComponent<Rigidbody>();
        tempRb.isKinematic = true; // Make it kinematic so it doesn't fall under gravity

        // Apply a random force to the temporary Rigidbody
        tempRb.AddForce(Random.insideUnitSphere * shakeForce, ForceMode.Impulse);

        // Destroy the temporary Rigidbody after the duration
        Destroy(tempRb, shakeDuration);
    }
}