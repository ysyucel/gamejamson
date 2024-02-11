using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Rumble : MonoBehaviour
{

    public Ease rumbleEase = Ease.InOutCirc;
    public float durationMultiplier = 1.02f;
    public float minRumbleDuration = 0.5f;
    public float rumbleSideDuration = 0.1f;
    public float rumbleSideDecrease = 0.01f;
    public Vector2 maxRumbleAngle = new Vector2(3, 5);
    public Vector2 minRumbleAngle = new Vector2(0.1f, 1);
    //public Vector2 waitDurations = new Vector2(0.3f, 2f);

    public bool isLinear;

    


    float targetAngle, currentAngle, limitAngle;

    [Header("Linear")]
    float currentPos, targetPos;
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

        currentPos = 0;
        currentPos = transform.position.x;
        limitAngle = Random.Range(minRumblePos.x, minRumblePos.y);
        targetPos = limitAngle;
        rumbleSideDuration *= 2;

        while (true)
        {
            yield return DOVirtual.Float(currentPos, targetPos, rumbleSideDuration, UpdatePos).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentPos = targetPos;
            //targetAngle /= -durationMultiplier;
            targetPos *= -durationMultiplier;
            if (rumbleSideDuration > minRumbleDuration)
                rumbleSideDuration -= rumbleSideDecrease;


            if (Mathf.Abs(targetPos) >= maxRumblePos.y)
                break;
        }

        StartCoroutine(nameof(LinearFastToSlow));
    }

    IEnumerator LinearFastToSlow()
    {
        DOTween.Kill("Angle");
        yield return null;
        targetPos = Random.Range(maxRumblePos.x, maxRumblePos.y);
        if (currentPos < 0)
            targetPos *= -1;
        //currentAngle = 0;
        limitAngle = Random.Range(minRumblePos.x, minRumblePos.y);



        while (true)
        {
            yield return DOVirtual.Float(currentPos, targetPos, rumbleSideDuration, UpdatePos).SetEase(rumbleEase).SetId("Angle").WaitForCompletion();
            currentPos = targetPos;
            targetPos /= -durationMultiplier;


            //if (Mathf.Abs(targetAngle) <= limitAngle)
            // break;
        }
    }

 

    int randomAxis;

    void UpdatePos(float pos)
    {
       
        transform.position = new Vector3(pos, transform.position.y, transform.position.z); // * randomAxis);

       //while(transform.position.x != pos)
       

       /* while (Mathf.Abs(transform.position.x - pos) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos, transform.position.y, transform.position.z), 0.0001f);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, pos * RandomizedAxis()), 0.0001f);

        }*/


        randomAxis = RandomizedAxis();
      
       // transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, pos * randomAxis), 0.0001f);
        


       // transform.position = new Vector3(transform.position.x, transform.position.y, pos * RandomizedAxis()) ;
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
