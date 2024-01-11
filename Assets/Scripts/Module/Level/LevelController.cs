using UnityEngine;

// LevelController sınıfı, seviye seçim ekranının kontrolünü sağlar.
public class LevelController : BaseController
{
    // LevelController sınıfının yapıcı metodu
    public LevelController() : base()
    {
        // Seviye seçim ekranını kayıt et
        GameApp.ViewManager.Register(ViewType.SelectLevelView, new ViewInfo()
        {
            prefabName = "SelectLevelView",
            baseController = this,
            parentTransform = GameApp.ViewManager.canvasTransform,
        });

        // Modül event'lerini başlat
        InitModuleEvent();
    }

    // Modül event'lerini başlatan metot
    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenSelectLevelView, OpenSelectLevelView);
    }

    // Seviye seçim ekranını açan metot
    private void OpenSelectLevelView(System.Object[] args)
    {
        GameApp.ViewManager.Open(ViewType.SelectLevelView, args);
        Debug.Log("SelectLevelView görünümü açıldı.");
    }
}
