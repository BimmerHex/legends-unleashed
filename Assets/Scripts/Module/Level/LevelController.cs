using UnityEngine;

// LevelController sınıfı, seviye seçim ekranının kontrolünü sağlar.
public class LevelController : BaseController
{
    // LevelController sınıfının yapıcı metodu
    public LevelController() : base()
    {
        SetModel(new LevelModel());

        // Seviye seçim ekranını kayıt et
        GameApp.ViewManager.Register(ViewType.SelectLevelView, new ViewInfo()
        {
            prefabName = "SelectLevelView",
            baseController = this,
            parentTransform = GameApp.ViewManager.canvasTransform,
        });

        // Modül event'lerini başlat
        InitModuleEvent();
        InitGlobalEvent();
    }

    public override void Init()
    {
        _baseModel.Init();
    }

    // Modül event'lerini başlatan metot
    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenSelectLevelView, OpenSelectLevelView);
    }

    public override void InitGlobalEvent()
    {
        GameApp.MessageCenter.AddEvent(Defines.ShowLevelDescriptionEvent, OnShowLevelDescriptionCallback);
        GameApp.MessageCenter.AddEvent(Defines.HideLevelDescriptionEvent, OnHideLevelDescriptionCallback);
    }

    public override void RemoveGlobalEvent()
    {
        GameApp.MessageCenter.RemoveEvent(Defines.ShowLevelDescriptionEvent, OnShowLevelDescriptionCallback);
        GameApp.MessageCenter.RemoveEvent(Defines.HideLevelDescriptionEvent, OnHideLevelDescriptionCallback);
    }

    private void OnShowLevelDescriptionCallback(System.Object arg) {
        Debug.Log($"Level ID: {arg.ToString()}");
        LevelModel levelModel = GetModel<LevelModel>();
        levelModel.currentLevel = levelModel.GetLevel(int.Parse(arg.ToString()));
        GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).ShowLevelDescription();
    }

    private void OnHideLevelDescriptionCallback(System.Object arg) {
        GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).HideLevelDescription();
    }

    // Seviye seçim ekranını açan metot
    private void OpenSelectLevelView(System.Object[] args)
    {
        GameApp.ViewManager.Open(ViewType.SelectLevelView, args);
        Debug.Log("SelectLevelView görünümü açıldı.");
    }
}
