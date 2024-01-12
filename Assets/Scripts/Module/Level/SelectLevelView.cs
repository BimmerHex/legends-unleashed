using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Seviye seçim ekranının kontrolünü sağlayan SelectLevelView sınıfı
public class SelectLevelView : BaseView
{
    // Start metodu üzerine yazılmış özel bir metot
    private protected override void OnStart()
    {
        // BaseView sınıfının OnStart metodunu çağır
        base.OnStart();
        // "Close" butonuna tıklanma olayına dinleyici eklenir ve OnCloseButton metodu atanır
        Find<Button>("Close").onClick.AddListener(OnCloseButton);
        // "Challenge" butonuna tıklanma olayına dinleyici eklenir ve OnChallengeButton metodu atanır
        Find<Button>("Level/Challenge").onClick.AddListener(OnChallengeButton);
    }

    // "Close" butonuna tıklandığında çağrılan metot
    private void OnCloseButton()
    {
        // Seviye seçim ekranını kapat
        GameApp.ViewManager.Close(ViewId);
        Debug.Log("SelectLevelView görünümü kapandı.");

        // Yüklenen sahneyi değiştirip ana menüyü açma işlemi
        LoadingModel loadingModel = new LoadingModel();
        loadingModel.sceneName = "MainMenu";
        loadingModel.sceneCallback = delegate ()
        {
            // GameUIController üzerinden StartView'i açma event'ini çağır
            BaseController.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
        };

        // LoadingController üzerinden yeni sahneyi yükleme işlemi
        BaseController.ApplyControllerFunc(ControllerType.Loading, Defines.OpenLoadingSceneView, loadingModel);
    }

    // Seviye açıklamasını gösteren metot
    public void ShowLevelDescription()
    {
        // "Level" objesini etkinleştir
        Find("Level").SetActive(true);
        // Şu anki seviyenin verilerini al
        LevelData currentLevelData = BaseController.GetModel<LevelModel>().currentLevel;
        // Seviye adını ve açıklamayı ekrana yazdır
        Find<TextMeshProUGUI>("Level/Level Name/Text").text = currentLevelData.name;
        Find<TextMeshProUGUI>("Level/Description/Text").text = currentLevelData.description;
    }

    // Seviye açıklamasını gizleyen metot
    public void HideLevelDescription()
    {
        // "Level" objesini devre dışı bırak
        Find("Level").SetActive(false);
    }

    // "Challenge" butonuna tıklandığında çağrılan metot
    private void OnChallengeButton()
    {
        // Seviye seçim ekranını kapat
        GameApp.ViewManager.Close(ViewId);
        Debug.Log("SelectLevelView görünümü kapandı.");

        // Kameranın pozisyonunu sıfırla
        GameApp.CameraManager.ResetPos();

        // Yeni bir sahneyi yüklemek için LoadingModel oluştur
        LoadingModel loadingModel = new LoadingModel();
        loadingModel.sceneName = BaseController.GetModel<LevelModel>().currentLevel.sceneName;
        loadingModel.sceneCallback = delegate ()
        {
            // Boş callback, gerekirse doldurulabilir
        };

        // LoadingController üzerinden yeni sahneyi yükleme işlemi
        BaseController.ApplyControllerFunc(ControllerType.Loading, Defines.OpenLoadingSceneView, loadingModel);
    }
}
