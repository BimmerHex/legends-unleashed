using UnityEngine;

// LevelController sınıfı, seviye seçim ekranının kontrolünü sağlar.
public class LevelController : BaseController
{
    // LevelController sınıfının yapıcı metodu
    public LevelController() : base()
    {
        // LevelController'ın modelini başlat
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

        // Global event'leri başlat
        InitGlobalEvent();
    }

    // BaseController sınıfındaki soyut Init metodu uygulaması
    public override void Init()
    {
        // Temel modeli başlat
        _baseModel.Init();
    }

    // Modül event'lerini başlatan metot
    public override void InitModuleEvent()
    {
        // Seviye seçim ekranını açma event'ini kaydet
        RegisterFunc(Defines.OpenSelectLevelView, OpenSelectLevelView);
    }

    // Global event'leri başlatan metot
    public override void InitGlobalEvent()
    {
        // MessageCenter üzerinden seviye açıklamasını gösterme event'ini kaydet
        GameApp.MessageCenter.AddEvent(Defines.ShowLevelDescriptionEvent, OnShowLevelDescriptionCallback);

        // MessageCenter üzerinden seviye açıklamasını gizleme event'ini kaydet
        GameApp.MessageCenter.AddEvent(Defines.HideLevelDescriptionEvent, OnHideLevelDescriptionCallback);
    }

    // Global event'leri kaldıran metot
    public override void RemoveGlobalEvent()
    {
        // MessageCenter üzerinden seviye açıklamasını gösterme event'ini kaldır
        GameApp.MessageCenter.RemoveEvent(Defines.ShowLevelDescriptionEvent, OnShowLevelDescriptionCallback);

        // MessageCenter üzerinden seviye açıklamasını gizleme event'ini kaldır
        GameApp.MessageCenter.RemoveEvent(Defines.HideLevelDescriptionEvent, OnHideLevelDescriptionCallback);
    }

    // Seviye açıklamasını gösterme callback'i
    private void OnShowLevelDescriptionCallback(System.Object arg)
    {
        // Gelen argümanı kullanarak seviye ID'sini konsola yazdır
        Debug.Log($"Level ID: {arg.ToString()}");

        // LevelModel'i al ve seviye ID'sine göre mevcut seviyeyi ayarla
        LevelModel levelModel = GetModel<LevelModel>();
        levelModel.currentLevel = levelModel.GetLevel(int.Parse(arg.ToString()));

        // SelectLevelView'i al ve seviye açıklamasını göster
        GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).ShowLevelDescription();
    }

    // Seviye açıklamasını gizleme callback'i
    private void OnHideLevelDescriptionCallback(System.Object arg)
    {
        // SelectLevelView'i al ve seviye açıklamasını gizle
        GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).HideLevelDescription();
    }

    // Seviye seçim ekranını açan metot
    private void OpenSelectLevelView(System.Object[] args)
    {
        // Seviye seçim ekranını aç ve bu işlemi konsola logla
        GameApp.ViewManager.Open(ViewType.SelectLevelView, args);
        Debug.Log("SelectLevelView görünümü açıldı.");
    }
}
