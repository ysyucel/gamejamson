using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractable : XRGrabInteractable
{
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (isSelected)
        {
            print("selected");
            transform.DOMove(transform.position + Vector3.forward * 4, 0.5f);
        }
    }
}
