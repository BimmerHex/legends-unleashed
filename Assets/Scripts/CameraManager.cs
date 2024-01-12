using UnityEngine;

// Kamera yönetimini sağlayan CameraManager sınıfı
public class CameraManager
{
    private Transform cameraTransform; // Kamera nesnesinin Transform bileşeni
    private Vector3 previousPosition; // Kameranın önceki pozisyonunu tutan değişken

    // CameraManager sınıfının yapıcı metodu
    public CameraManager()
    {
        // Kamera nesnesinin Transform bileşenini al
        cameraTransform = Camera.main.transform;
        // Kameranın başlangıç pozisyonunu kaydet
        previousPosition = cameraTransform.transform.position;
    }

    // Kameranın pozisyonunu belirli bir pozisyona ayarlayan metot
    public void SetPos(Vector3 pos)
    {
        // Z ekseni pozisyonunu koruyarak kameranın pozisyonunu ayarla
        pos.z = cameraTransform.position.z;
        cameraTransform.transform.position = pos;
    }

    // Kameranın pozisyonunu önceki pozisyona sıfırlayan metot
    public void ResetPos()
    {
        // Kameranın pozisyonunu önceki pozisyona ayarla
        cameraTransform.transform.position = previousPosition;
    }
}
