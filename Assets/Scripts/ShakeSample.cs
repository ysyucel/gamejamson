using UnityEngine;

public class ShakeSample : MonoBehaviour
{

    public Vector3 startPosition;

    public GameObject objectToShake;
    public float oneCycleTime = 1f;
    public float shakeDuration = 15f;
    public Vector3 maxShakePosition;
    float time = 0f;
    float totalTime=0f;
    private int xId, yId, zId;
    public float shakeScale = 1f;
    bool isStart = false;
    void Start()
    {
        startPosition=transform.position; ;
       
        Debug.Log(gameObject.name);
    }
    public void Update()
    {
        if (isStart) { 
            totalTime += Time.deltaTime;
            time += Time.deltaTime;
        }
    }
    public void StartEarthQuake()
    {
        isStart = true;
        // Eğriyi kullanarak titreme efektini simüle et
        xId = LeanTween.moveX(objectToShake, objectToShake.transform.position.x + maxShakePosition.x , oneCycleTime).setEaseInBounce().setLoopPingPong(1).id;
        yId = LeanTween.moveY(objectToShake, objectToShake.transform.position.y + maxShakePosition.y, oneCycleTime).setEaseInBounce().setLoopPingPong(1).id;
        zId = LeanTween.moveZ(objectToShake, objectToShake.transform.position.z + maxShakePosition.z, oneCycleTime).setEaseInBounce().setLoopPingPong(1).setOnComplete(EndingLean).id;

    }
    public void EndingLean()
    {
        LeanTween.cancel(xId);
        LeanTween.cancel(yId);
        LeanTween.cancel(zId);
        time = 0f;
        if (totalTime < shakeDuration)
        {
            StartEarthQuake();
        }
    }
}