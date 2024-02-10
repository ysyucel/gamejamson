using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Rumble : MonoBehaviour
{

    public Ease rumbleEase = Ease.InOutCirc;
    public float durationMultiplier = 1.02f;
    public float rumbleSideDuration = 0.1f;
    public Vector2 maxRumbleAngle = new Vector2 (3,5);
    public Vector2 minRumbleAngle = new Vector2 (0.1f, 1);
    public Vector2 waitDurations = new Vector2(0.3f, 2f);



    public void Start()
    {
        StartCoroutine(nameof(RumbleRoutine));
    }

    IEnumerator RumbleRoutine()
    {
        DOTween.Kill("Angle");
        yield return null;
        float targetAngle = Random.Range(maxRumbleAngle.x, maxRumbleAngle.y);
        float currentAngle = 0;
        float limit = Random.Range(minRumbleAngle.x, minRumbleAngle.y);
        while(true)
        {
            yield return DOVirtual.Float(currentAngle, targetAngle, rumbleSideDuration, UpdateAngle).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentAngle = targetAngle;
            targetAngle /= -durationMultiplier;


            if (Mathf.Abs(targetAngle) <= limit)
                break;
        }

         yield return new WaitForSeconds(Random.Range(waitDurations.x, waitDurations.y));
         StartCoroutine(nameof(RumbleRoutine));

    }

    void UpdateAngle(float angle)
    {
        transform.localEulerAngles = new Vector3(angle, 0, 0);
    }


}
