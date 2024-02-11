using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class Hold : MonoBehaviour
{

    private XRSimpleInteractable grabInteractable;
    private float initialScale;
    private float maxScale = 3.0f; 
    public float pushRate = 0.01f;
    public float growRate = 0.5f;
    public Camera cam;

    public Transform startObj;


     Vector3 startPos;
    Quaternion startRot;


    Vector3 direction;

    private void Start()
    {
        cam = Camera.main;
        startObj = transform;
        startPos = startObj.transform.position;
        startRot = startObj.transform.rotation;

        grabInteractable = GetComponent<XRSimpleInteractable>();
        initialScale = transform.localScale.x;

        direction = (startObj.transform.position - transform.position).normalized;
    }

   
    private void Update()
    {
        
        if (grabInteractable.isSelected)
        {
            //ScaleObject();
            PushObject();
        }

        
    }


    public float duration = 2f;
    public void EnteredSelection()
    {
        // transform.DOMove(startPos, duration).SetId("Push").SetSpeedBased();
        // transform.DORotateQuaternion(startRot, duration).SetId("Rotate").SetSpeedBased();
    }

    public void ExitSelection()
    {
        // DOTween.Kill("Push");
        // DOTween.Kill("Rotate");
    }



    private void ScaleObject()
    {
        if (transform.localScale.x < maxScale)
        {
            float newScale = transform.localScale.x + growRate * Time.deltaTime;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    private void PushObject()
    {
        //Vector3 direction = (cam.transform.position - transform.position).normalized;
       
        transform.position += -direction * pushRate;
    }
}
