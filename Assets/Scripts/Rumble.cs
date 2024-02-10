using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Rumble : MonoBehaviour
{

    public Ease rumbleEase = Ease.InOutCirc;
    public float rumbleTime = 0.5f;
    public float maxAngle = 5;
    public float deceleration = 1.02f;
    public Vector2 limitAngle = new Vector2 (0.1f, 1);
    public Vector2 waitDurations = new Vector2(0.3f, 2f);



    public void Start()
    {
        StartCoroutine(nameof(RumbleRoutine));
    }

    IEnumerator RumbleRoutine()
    {
        DOTween.Kill("Angle");
        yield return null;
        float targetAngle = maxAngle;
        float currentAngle = 0;
        float limit = Random.Range(limitAngle.x, limitAngle.y);
        while(true)
        {
            yield return DOVirtual.Float(currentAngle, targetAngle, rumbleTime, UpdateAngle).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentAngle = targetAngle;
            targetAngle /= -deceleration;


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
