using UnityEngine;
using UnityEngine.UI;

// ChallengeView sınıfı, meydan okuma ekranının kontrolünü sağlar.
public class ChallengeView : BaseView
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
        // Meydan okuma ekranını kapat
        GameApp.ViewManager.Close(ViewId);
        Debug.Log("ChallengeView görünümü kapandı.");

        // Yüklenen sahneyi değiştirip ana menüyü açma işlemi
        LoadingModel loadingModel = new LoadingModel();
        loadingModel.sceneName = "Map";  // Yüklenen sahnenin adı
        loadingModel.sceneCallback = delegate ()
        {
            // LevelController üzerinden OpenSelectLevelView event'ini çağır
            BaseController.ApplyControllerFunc(ControllerType.Level, Defines.OpenSelectLevelView);
        };

        // LoadingController üzerinden yeni sahneyi yükleme işlemi
        BaseController.ApplyControllerFunc(ControllerType.Loading, Defines.OpenLoadingSceneView, loadingModel);
    }
}
