using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    // Shake süresi
    public float duration = 1f;

    // Shake miktarı
    public Vector3 strength = new Vector3(1f, 1f, 1f);

    // Shake periyodu
    public int vibrato = 10;

    // Shake'in sertliği
    public float randomness = 90f;

    // Shake'i hangi eksende kullanacağımızı belirtir.
    public bool useX = true;
    public bool useY = true;
    public bool useZ = true;
    public void Start()
    {
        StartShakeAfterDelay(4f);
    }
    // Shake'in başlamasını sağlar
    public void ShakeObject()
    {
        // Eğer nesne seçilmediyse çık
        if (gameObject == null)
            return;

        // Shake efektini uygula
        transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
    }

    // İsteğe bağlı olarak belirli bir süre sonra shake'i başlatır
    public void StartShakeAfterDelay(float delay)
    {
        Invoke("ShakeObject", delay);
    }
}