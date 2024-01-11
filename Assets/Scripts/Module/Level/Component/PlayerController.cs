using UnityEngine;

// PlayerController sınıfı, oyuncu kontrolünü sağlar.
public class PlayerController : MonoBehaviour
{
    // Start metodu, nesne oluşturulduğunda çağrılır
    private void Start()
    {
        // Kameranın pozisyonunu oyuncunun pozisyonuna ayarla
        GameApp.CameraManager.SetPos(transform.position);
    }

    // Update metodu, her bir frame'de çağrılır
    private void Update()
    {
        // Oyuncu kontrol işlemleri burada yapılabilir
    }
}
