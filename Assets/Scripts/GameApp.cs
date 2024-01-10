using UnityEngine;

// Oyun uygulamasının ana sınıfı
public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager; // Ses yöneticisi nesnesi
    public static ControllerManager ControllerManager; // Controller yöneticisi nesnesi
    public static ViewManager ViewManager; // Görünüm yöneticisi nesnesi

    // Başlatma işlemleri için kullanılan override edilmiş metot
    public override void Init() {
        SoundManager = new SoundManager(); // Ses yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda SoundManager sınıfı başlatıldı.");
        ControllerManager = new ControllerManager(); // Controller yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda ControllerManager sınıfı başlatıldı.");
        ViewManager = new ViewManager(); // Görünüm yöneticisini başlat
        Debug.Log("GameApp sınıfının Init metodunda ViewManager sınıfı başlatıldı.");
    }
}
