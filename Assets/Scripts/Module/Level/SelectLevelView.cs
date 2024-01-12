using TMPro;
using UnityEngine;
using UnityEngine.UI;

// SelectLevelView sınıfı, seviye seçim ekranının kontrolünü sağlar.
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

    public void ShowLevelDescription() {
        Find("Level").SetActive(true);
        LevelData currentLevelData = BaseController.GetModel<LevelModel>().currentLevel;
        Find<TextMeshProUGUI>("Level/Level Name/Text").text = currentLevelData.name;
        Find<TextMeshProUGUI>("Level/Description/Text").text = currentLevelData.description;
    }

    public void HideLevelDescription() {
        Find("Level").SetActive(false);
    }

    private void OnChallengeButton() {
        GameApp.ViewManager.Close(ViewId);
        Debug.Log("SelectLevelView görünümü kapandı.");

        GameApp.CameraManager.ResetPos();
        
        LoadingModel loadingModel = new LoadingModel();
        loadingModel.sceneName = BaseController.GetModel<LevelModel>().currentLevel.sceneName;
        loadingModel.sceneCallback = delegate () {
            
        };

        BaseController.ApplyControllerFunc(ControllerType.Loading, Defines.OpenLoadingSceneView, loadingModel);
    }
}
