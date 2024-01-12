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
    }

    public void HideLevelDescription() {
        Find("Level").SetActive(false);
    }
}
