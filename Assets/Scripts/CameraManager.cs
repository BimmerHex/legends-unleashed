using UnityEngine;

// CameraManager sınıfı, kamera yönetimini sağlar.
public class CameraManager
{
    private Transform cameraTransform;
    private Vector3 previousPosition;

    // CameraManager sınıfının yapıcı metodu
    public CameraManager()
    {
        cameraTransform = Camera.main.transform;
    }

    // Kameranın pozisyonunu belirli bir pozisyona ayarlayan metot
    public void SetPos(Vector3 pos)
    {
        pos.z = cameraTransform.position.z;
        cameraTransform.transform.position = pos;
    }

    // Kameranın pozisyonunu önceki pozisyona sıfırlayan metot
    public void ResetPos()
    {
        cameraTransform.transform.position = previousPosition;
    }
}
