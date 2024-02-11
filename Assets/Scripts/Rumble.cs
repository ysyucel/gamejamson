using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Rumble : MonoBehaviour
{

    public Ease rumbleEase = Ease.InOutCirc;
    public float accelerator = 1.02f;
    public float minRumbleDuration = 0.5f;
    public float rumbleSideDuration = 0.1f;
    public float rumbleSideDecrease = 0.01f;
   //public Vector2 maxRumbleAngle = new Vector2(3, 5);
    //public Vector2 minRumbleAngle = new Vector2(0.1f, 1);
    //public Vector2 waitDurations = new Vector2(0.3f, 2f);

    public bool isLinear;

    


    float targetAngle, currentAngle, limitPos;

    [Header("Linear")]
    float currentX, targetPosX;
    public Vector2 maxRumblePos, minRumblePos;



    public void Start()
    {
        if(isLinear)
            StartCoroutine(nameof(LinearSlowToFast));
       // else
           // StartCoroutine(nameof(SlowToFast));
    }

    IEnumerator LinearSlowToFast()
    {
        DOTween.Kill("Angle");
        yield return null;

       // currentPos = 0;
        currentX = 0;
        limitPos = Random.Range(minRumblePos.x, minRumblePos.y);
        targetPosX =  limitPos;
        rumbleSideDuration *= 2;
       
        while (true)
        {
            yield return DOVirtual.Float(currentX, targetPosX, rumbleSideDuration, UpdatePos).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentX = targetPosX;
            targetPosX *= -accelerator;

           
            

            if (rumbleSideDuration > minRumbleDuration)
                rumbleSideDuration -= rumbleSideDecrease;


            if (Mathf.Abs(targetPosX) >= maxRumblePos.y + targetPosX)
                break;
        }

        StartCoroutine(nameof(LinearFastToSlow));
    }

    IEnumerator LinearFastToSlow()
    {
        DOTween.Kill("Angle");
        yield return null;
        targetPosX = Random.Range(maxRumblePos.x, maxRumblePos.y);
        if (currentX < 0)
            targetPosX *= -1;
       
        limitPos = Random.Range(minRumblePos.x, minRumblePos.y);



        while (true)
        {
            yield return DOVirtual.Float(currentX, targetPosX, rumbleSideDuration, UpdatePos).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentX = targetPosX;
            targetPosX /= -accelerator;


            //if (Mathf.Abs(targetAngle) <= limitAngle)
            // break;
        }
    }

 

    int randomAxis;

    void UpdatePos(float pos)
    {
       
        transform.position = new Vector3(transform.position.x + pos, transform.position.y, transform.position.z); // * randomAxis);
        randomAxis = RandomizedAxis();

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + pos * RandomizedAxis()) ;
    }

    int RandomizedAxis()
    {
        do
        {
            randomAxis = Random.Range(-1, 2);
        } while (randomAxis == 0);

        return randomAxis;
    }


    /*IEnumerator SlowToFast()
 {
     DOTween.Kill("Angle");
     yield return null;
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

     StartCoroutine(nameof(FastToSlow));

 }




 IEnumerator FastToSlow()
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
 }*/



}
