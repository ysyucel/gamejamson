using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Rumble : MonoBehaviour
{

    public Ease rumbleEase = Ease.InOutCirc;
    public float durationMultiplier = 1.02f;
    public float rumbleSideDuration = 0.1f;
    public float rumbleSideDecrease = 0.01f;
    public Vector2 maxRumbleAngle = new Vector2(3, 5);
    public Vector2 minRumbleAngle = new Vector2(0.1f, 1);
    //public Vector2 waitDurations = new Vector2(0.3f, 2f);


    float targetAngle, currentAngle, limitAngle;


    public void Start()
    {
        //StartCoroutine(nameof(RumbleRoutine));
        //StartCoroutine(nameof(SlowRumbleRoutine));
        StartCoroutine(nameof(SlowToFast));
    }

    IEnumerator SlowToFast()
    {
        DOTween.Kill("Angle");
        yield return null;
        //targetAngle = Random.Range(maxRumbleAngle.x, maxRumbleAngle.y);
        currentAngle = 0;
        limitAngle = Random.Range(minRumbleAngle.x, minRumbleAngle.y);
        targetAngle = limitAngle;
        rumbleSideDuration *= 2;



        while (true)
        {
            yield return DOVirtual.Float(currentAngle, targetAngle, rumbleSideDuration, UpdateAngle).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentAngle = targetAngle;
            //targetAngle /= -durationMultiplier;
            targetAngle *= -durationMultiplier;
            if(rumbleSideDuration > 0.1f)
                rumbleSideDuration -= rumbleSideDecrease;


            if (Mathf.Abs(targetAngle) >= maxRumbleAngle.y)
                break;
        }

        StartCoroutine(nameof(RumbleRoutine));

    }


    IEnumerator SlowRumbleRoutine()
    {
        DOTween.Kill("Angle");
        yield return null;
       
        limitAngle = Random.Range(minRumbleAngle.x, minRumbleAngle.y);
        currentAngle = Random.Range(maxRumbleAngle.x, maxRumbleAngle.y);

        targetAngle = targetAngle > 0 ? limitAngle : -limitAngle;
        while (true)
        {
            yield return DOVirtual.Float(currentAngle, targetAngle, rumbleSideDuration * 2, UpdateAngle).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentAngle = targetAngle;
            targetAngle *= -durationMultiplier;

            //if(rumbleSideDuration > 0.1f)
                rumbleSideDuration -= rumbleSideDecrease;

            print(targetAngle);

            if (Mathf.Abs(targetAngle) >= maxRumbleAngle.x)
            {
                break;

            }

        }
        StartCoroutine(nameof(RumbleRoutine));


    }

    IEnumerator RumbleRoutine()
    {
        DOTween.Kill("Angle");
        yield return null;
        targetAngle = Random.Range(maxRumbleAngle.x, maxRumbleAngle.y);
        if (currentAngle < 0)
            targetAngle *= -1;
        //currentAngle = 0;
        limitAngle = Random.Range(minRumbleAngle.x, minRumbleAngle.y);



        while (true)
        {
            yield return DOVirtual.Float(currentAngle, targetAngle, rumbleSideDuration, UpdateAngle).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentAngle = targetAngle;
            targetAngle /= -durationMultiplier;


            //if (Mathf.Abs(targetAngle) <= limitAngle)
            // break;
        }

        //yield return new WaitForSeconds(Random.Range(waitDurations.x, waitDurations.y));
        //StartCoroutine(nameof(RumbleRoutine));

    }

    void UpdateAngle(float angle)
    {
        transform.localEulerAngles = new Vector3(angle, 0, 0);
    }


}
