using UnityEngine;

// Oyun sahnesinin ana script'i
public class GameScene : MonoBehaviour
{
    public Texture2D mouseTexture; // Fare imleci texture'ını tutan değişken

    private float dt; // Delta time değerini tutan değişken
    private bool isLoaded = false; // Sahnenin yüklenip yüklenmediğini kontrol eden değişken

    // Awake metodu, sahne başladığında çalışır
    private void Awake() {
        if (isLoaded) {
            Destroy(gameObject);
        } else {
            isLoaded = true;
            DontDestroyOnLoad(gameObject);

            // GameApp singleton'ını başlat ve bir log mesajı yazdır
            Debug.Log("GameApp sınıfını başlatmak için Init metodu çağrılıyor.");
            GameApp.Instance.Init();
            Debug.Log("Init metodu çalıştırıldı.");
        }
    }

    // Start metodu, Awake metodu tamamlandıktan sonra çalışır
    private void Start() {
        // Fare imlecini belirtilen texture ile değiştir
        // Cursor.SetCursor(mouseTexture, Vector2.zero, CursorMode.Auto);
        // Debug.Log("Cursor sınıfındaki SetCursor metodu çalıştırıldı ve mouse imleci değiştirildi.");

        // Arkaplan müziğini çalmak için SoundManager üzerinden PlayBGM metodu çağrılıyor
        Debug.Log("SoundManager sınıfındaki PlayBGM metodu çağrılıyor.");
        GameApp.SoundManager.PlayBGM("Background");

        // Controller'ları kaydet ve modülleri başlat
        RegisterModule();
        InitModule();
    }

    // Controller'ları kaydetmek için kullanılan metot
    private void RegisterModule() {
        GameApp.ControllerManager.Register(ControllerType.GameUI, new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game, new GameController());
        GameApp.ControllerManager.Register(ControllerType.Loading, new LoadingController());
    }

    // Modülleri başlatmak için kullanılan metot
    private void InitModule() {
        GameApp.ControllerManager.InitAllModules();
    }

    // Update metodu, her bir frame'de çağrılır
    private void Update() {
        // Zaman aralığını güncelle
        dt = Time.deltaTime;
        Debug.Log("GameApp sınıfının virtual olan Update metodu çağrılıyor.");

        // GameApp singleton'ını güncelle ve bir log mesajı yazdır
        GameApp.Instance.Update(dt);
    }
}
