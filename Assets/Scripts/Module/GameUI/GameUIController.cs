using UnityEngine;

// BaseController sınıfından türetilen GameUIController sınıfı
public class GameUIController : BaseController
{
    // GameUIController'ın yapıcı metodu
    public GameUIController() : base() {
        // ViewManager'a StartView'ı kaydet
        GameApp.ViewManager.Register(ViewType.StartView, new ViewInfo() {
            prefabName = "StartView",
            baseController = this,
            parentTransform = GameApp.ViewManager.canvasTransform
        });
        // ViewManager'a SettingsView'ı kaydet
        GameApp.ViewManager.Register(ViewType.SettingsView, new ViewInfo() {
            prefabName = "SettingsView",
            baseController = this,
            sortingOrder = 1,
            parentTransform = GameApp.ViewManager.canvasTransform
        });
        // ViewManager'a MessageView'ı kaydet
        GameApp.ViewManager.Register(ViewType.MessageView, new ViewInfo() {
            prefabName = "MessageView",
            baseController = this,
            sortingOrder = 999,
            parentTransform = GameApp.ViewManager.canvasTransform
        });

        // Modül event'lerini ve global event'leri başlat
        InitModuleEvent();
        InitGlobalEvent();
    }

    // BaseController sınıfından miras alınan sanal metot, modül event'lerini başlatır
    public override void InitModuleEvent()
    {
        // Defines sınıfındaki (a) event'ini (b) metoduna bağla
        RegisterFunc(Defines.OpenStartView, OpenStartView);
        RegisterFunc(Defines.OpenSettingsView, OpenSettingsView);
        RegisterFunc(Defines.OpenMessageView, OpenMessageView);

    }

    // OpenStartView metodunu çağıran metot
    private void OpenStartView(System.Object[] args) {
        // ViewManager aracılığıyla StartView'ı aç
        GameApp.ViewManager.Open(ViewType.StartView, args);
        Debug.Log("StartView görünümü açıldı.");
    }

    // OpenSettingsView metodunu çağıran metot
    private void OpenSettingsView(System.Object[] args) {
        // ViewManager aracılığıyla SettingsView'ı aç
        GameApp.ViewManager.Open(ViewType.SettingsView, args);
        Debug.Log("SettingsView görünümü açıldı.");
    }

    // OpenMessageView metodunu çağıran metot
    private void OpenMessageView(System.Object[] args) {
        // ViewManager aracılığıyla MessageView'ı aç
        GameApp.ViewManager.Open(ViewType.MessageView, args);
        Debug.Log("MessageView görünümü açıldı.");
    }
}
