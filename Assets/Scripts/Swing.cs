using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float maxRotation = 30f; // Maksimum dönüş açısı
    public float shakeDuration = 1f; // Sallanma süresi

    void Start()
    {
        // Nesneyi rastgele döndürerek sallamak için Shake metodu çağrılır
        Shake();
    }

    void Shake()
    {
        // Rastgele dönüş açısı oluşturulur
        Vector3 randomRotation = new Vector3(Random.Range(-maxRotation, maxRotation),
                                             Random.Range(-maxRotation, maxRotation),
                                             Random.Range(-maxRotation, maxRotation));

        // LeanTween kütüphanesi kullanılarak rastgele döndürme işlemi gerçekleştirilir
        LeanTween.rotateLocal(gameObject, randomRotation, shakeDuration)
                 .setEase(LeanTweenType.easeInOutQuad) // Kolaylık türü (opsiyonel)
                 .setOnComplete(() =>
                 {
                     // Shake işlemi tamamlandığında, nesneyi başlangıç rotasyonuna geri getir
                     LeanTween.rotateLocal(gameObject, Vector3.zero, 0.1f);
                 });
    }
}
