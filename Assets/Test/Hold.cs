using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hold : MonoBehaviour
{

    private XRSimpleInteractable grabInteractable;
    private float initialScale;
    private float maxScale = 3.0f; 
    private float growthRate = 0.5f; 

    private void Start()
    {
        grabInteractable = GetComponent<XRSimpleInteractable>();
        initialScale = transform.localScale.x;
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            ScaleObject();
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
}
