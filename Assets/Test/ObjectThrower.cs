using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectThrower : MonoBehaviour
{
    public Vector2 force = new Vector2(700, 1000);
    public Vector2 waitDuration = new Vector2(.5f, 2);

    Vector3 direction;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        EventBus.OnRumble += Throw;
    }
    public void GetDirection() 
    {
        direction = Vector3.zero;

        do
        {
            direction = UnityEngine.Random.onUnitSphere;
        } while (direction.y < 0f);
        direction = UnityEngine.Random.onUnitSphere;
    }
    void Throw()
    {
        StartCoroutine(nameof(ThrowRoutine));
    }

    void GiveRandomForce()
    {
        rb.AddForce(direction * UnityEngine.Random.Range(force.x, force.y));

    }

    IEnumerator ThrowRoutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(waitDuration.x, waitDuration.y));
        GetDirection();
        GiveRandomForce();
    }

    private void OnDisable()
    {
        EventBus.OnRumble -= Throw;
    }
}
