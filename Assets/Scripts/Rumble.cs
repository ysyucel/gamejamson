using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class Rumble : MonoBehaviour
{

    public float lastVelocity = 1;
    public Ease rumbleEase = Ease.InOutCirc;
    public float rumbleTime = 0.5f;
   // public float rumbleTimeCheck = 0.5f;
    public float angleMultiplier = 1;
    public float deceleration = 1.1f;


    public void Start()
    {
        StartCoroutine(nameof(RumbleRoutine));
       // rumbleTimeCheck = rumbleTime;
    }

    IEnumerator RumbleRoutine()
    {
        DOTween.Kill("Angle");
        yield return null;
        float targetAngle = lastVelocity * angleMultiplier;
        float currentAngle = 0;
        while(true)//(rumbleTimeCheck<0f)
        {
            yield return DOVirtual.Float(currentAngle, targetAngle, rumbleTime, UpdateAngle).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
           // rumbleTimeCheck -= Time.deltaTime;
            currentAngle = targetAngle;
            targetAngle /= -deceleration;
        }

        // yield return new WaitForSeconds(2);
        // rumbleTimeCheck = rumbleTime;
        // StartCoroutine(nameof(RumbleRoutine));



    }

    void UpdateAngle(float angle)
    {
        transform.localEulerAngles = new Vector3(angle, 0, 0);
    }


}
