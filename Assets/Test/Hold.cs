using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hold : MonoBehaviour
{

    private XRSimpleInteractable grabInteractable;
    private float initialScale;
    private float maxScale = 3.0f; 
    public float growthRate = 0.01f;
    public Camera cam;

    private void Start()
    {
        cam = Camera.main;
        grabInteractable = GetComponent<XRSimpleInteractable>();
        initialScale = transform.localScale.x;
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            //ScaleObject();
            PushObject();
        }
    }

    private void ScaleObject()
    {
        if (transform.localScale.x < maxScale)
        {
            float newScale = transform.localScale.x + growthRate * Time.deltaTime;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    private void PushObject()
    {
        Vector3 direction = (cam.transform.position - transform.position).normalized;
        transform.position += -direction * growthRate;
    }
}
