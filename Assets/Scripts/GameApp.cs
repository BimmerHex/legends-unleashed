using UnityEngine;

// Oyun uygulamasının ana sınıfı
public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager; // Ses yöneticisi nesnesi
    public static ControllerManager ControllerManager; // Controller yöneticisi nesnesi
    public static ViewManager ViewManager; // Görünüm yöneticisi nesnesi
    public static ConfigManager ConfigManager; // Yapılandırma yöneticisi nesnesi
    public static CameraManager CameraManager; // Kamera yöneticisi nesnesi
    public static MessageCenter MessageCenter; // İletişim merkezi nesnesi

    // Başlatma işlemleri için kullanılan override edilmiş metot
    public override void Init() {
        CameraManager = new CameraManager(); // Kamera yöneticisi başlat
        Debug.Log("GameApp sınıfının Init metodunda CameraManager sınıfı başlatıldı.");
        SoundManager = new SoundManager(); // Ses yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda SoundManager sınıfı başlatıldı.");
        ConfigManager = new ConfigManager(); // Yapılandırma yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda ConfigManager sınıfı başlatıldı.");
        ControllerManager = new ControllerManager(); // Controller yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda ControllerManager sınıfı başlatıldı.");
        ViewManager = new ViewManager(); // Görünüm yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda ViewManager sınıfı başlatıldı.");
        MessageCenter = new MessageCenter(); // İletişim merkezi başlat
        Debug.Log("GameApp sınıfının Init metodunda MessageCenter sınıfı başlatıldı.");
    }
}
