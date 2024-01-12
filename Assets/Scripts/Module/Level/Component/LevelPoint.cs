using UnityEngine;

public class LevelPoint : MonoBehaviour
{
    // Her seviye noktasına özgü bir kimlik
    public int levelId;

    // Bu metot, belirli bir nesnenin bu seviye noktasına giriş yaptığında tetiklenir
    private void OnTriggerEnter2D(Collider2D other)
    {
        // MessageCenter üzerinden, seviye açıklamasını gösterme olayını tetikle
        GameApp.MessageCenter.PostEvent(Defines.ShowLevelDescriptionEvent, levelId);

        // Konsola giriş yapılan seviye noktasının mesajını yazdır
        Debug.Log("Level noktasına girdin.");
    }

    // Bu metot, belirli bir nesnenin bu seviye noktasından çıkış yaptığında tetiklenir
    private void OnTriggerExit2D(Collider2D other)
    {
        // MessageCenter üzerinden, seviye açıklamasını gizleme olayını tetikle
        GameApp.MessageCenter.PostEvent(Defines.HideLevelDescriptionEvent, levelId);

        // Konsola çıkış yapılan seviye noktasının mesajını yazdır
        Debug.Log("Level noktasından çıktın.");
    }
}
