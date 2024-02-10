using UnityEngine;
using DG.Tweening;

public class Earthquake : MonoBehaviour
{
    // Shake süresi
    public float duration = 1f;

    // Başlangıçta titreme miktarı
    public Vector3 startStrength = new Vector3(1f, 1f, 1f);

    // Shake'in sertliği
    public float randomness = 90f;

    // Minimum ve maksimum titreme miktarı
    public float minStrengthMultiplier = 0.5f;
    public float maxStrengthMultiplier = 2f;

    public void Start()
    {
        StartEarthquakeAfterDelay(4f);
    }
    // Shake'in başlamasını sağlar
    public void StartEarthquake()
    {
        // Eğer nesne seçilmediyse çık
        if (gameObject == null)
            return;

        // Rastgele titreme miktarı belirle
        Vector3 randomStrength = new Vector3(
            Random.Range(startStrength.x * minStrengthMultiplier, startStrength.x * maxStrengthMultiplier),
            Random.Range(startStrength.y * minStrengthMultiplier, startStrength.y * maxStrengthMultiplier),
            Random.Range(startStrength.z * minStrengthMultiplier, startStrength.z * maxStrengthMultiplier)
        );

        // Shake efektini uygula
        transform.DOShakePosition(duration, randomStrength, vibrato: 10, randomness: randomness, fadeOut: true);
    }

    // İsteğe bağlı olarak belirli bir süre sonra shake'i başlatır
    public void StartEarthquakeAfterDelay(float delay)
    {
        Invoke("StartEarthquake", delay);
    }
}