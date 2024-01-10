using UnityEngine;
using UnityEngine.UI;

// BaseView sınıfından türetilen StartView sınıfı
public class StartView : BaseView
{
    // Awake metodu üzerine yazılmış özel bir metot
    private protected override void OnAwake()
    {
        // BaseView sınıfının OnAwake metodunu çağır
        base.OnAwake();
        
        // "Start" butonuna tıklanma olayına dinleyici eklenir ve OnStartGameButton metodu atanır
        Find<Button>("Start").onClick.AddListener(OnStartGameButton);
        // "Settings" butonuna tıklanma olayına dinleyici eklenir ve OnSettingsButton metodu atanır
        Find<Button>("Settings").onClick.AddListener(OnSettingsButton);
        // "Quit" butonuna tıklanma olayına dinleyici eklenir ve OnQuitGameButton metodu atanır
        Find<Button>("Quit").onClick.AddListener(OnQuitGameButton);
    }

    // "Start" butonuna tıklandığında çağrılan metot
    private void OnStartGameButton() {
        GameApp.ViewManager.Close(ViewId);
        
        LoadingModel loadingModel = new LoadingModel();
        loadingModel.sceneName = "Level_001";
        BaseController.ApplyControllerFunc(ControllerType.Loading, Defines.OpenLoadingScene, loadingModel);   
    }

    // "Settings" butonuna tıklandığında çağrılan metot
    private void OnSettingsButton() {
        ApplyFunc(Defines.OpenSettingsView); // Defines sınıfındaki OpenSettingsView event'ini çağır
    }

    // "Quit" butonuna tıklandığında çağrılan metot
    private void OnQuitGameButton() {
        BaseController.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenMessageView, new MessageInfo() {
            acceptCallBack = delegate() {
                Application.Quit();
            },
            messageText = "Are you sure you want to quit the game?"
        });
    }
}
