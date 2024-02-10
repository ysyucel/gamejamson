using UnityEngine;

public class ShakeSample : MonoBehaviour
{
    public GameObject objectToShake;
    public AnimationCurve shakeCurve;
    public float shakeStrength = 0.1f;
    public float shakeDuration = 0.5f;

    void Start()
    {
        // Eğriyi kullanarak titreme efektini simüle et
        LeanTween.move(objectToShake, Vector3.zero, shakeDuration)
                 .setEase(shakeCurve)
                 .setLoopPingPong(1)
                 .setOnUpdate((float val) =>
                 {
                     // Hareket değerine rastgele bir titreme uygula
                     Vector3 shakeAmount = Random.insideUnitSphere * shakeStrength;
                     objectToShake.transform.position += shakeAmount;
                 })
                 .setOnComplete(() =>
                 {
                     // Titreme tamamlandığında nesneyi başlangıç konumuna getir
                     objectToShake.transform.localPosition = Vector3.zero;
                 });
    }
}