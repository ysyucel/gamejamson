using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    public static Action OnRumble;
}
public class ObjectThrower : MonoBehaviour
{
    public Vector2 force = new Vector2(700, 1000);

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
        GetDirection();
        rb.AddForce(direction * UnityEngine.Random.Range(force.x, force.y));
    }

    private void OnDisable()
    {
        EventBus.OnRumble -= Throw;
    }
}
