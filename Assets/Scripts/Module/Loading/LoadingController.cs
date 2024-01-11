using UnityEngine;
using UnityEngine.SceneManagement;

// LoadingController sınıfı, BaseController sınıfından türetilmiştir.
public class LoadingController : BaseController
{
    private AsyncOperation asyncOperation; // Asenkron operasyonu takip etmek için kullanılan değişken

    // LoadingController sınıfının yapıcı metodu
    public LoadingController() : base() {
        // LoadingView'in ViewType'ını, prefab adını, BaseController'ını ve bağlı olacağı canvas'ı belirterek ViewManager'a kaydeder
        GameApp.ViewManager.Register(ViewType.LoadingView, new ViewInfo() {
            prefabName = "LoadingView",
            baseController = this,
            parentTransform = GameApp.ViewManager.canvasTransform
        });

        // Module'deki olayları başlatan metodu çağırır
        InitModuleEvent();
    }

    // Olayları başlatan metot
    public override void InitModuleEvent()
    {
        // OpenLoadingSceneView fonksiyonunu Defines.OpenLoadingSceneView olayına kaydeder
        RegisterFunc(Defines.OpenLoadingSceneView, OpenLoadingSceneView);
    }

    // Belirtilen bir sahneyi yükleyen metot
    private void OpenLoadingSceneView(System.Object[] args) {
        // Gelen argümanları LoadingModel tipine dönüştürerek loadingModel değişkenine atar
        LoadingModel loadingModel = args[0] as LoadingModel;

        // Model'i ayarlar
        SetModel(loadingModel);

        // LoadingView'i açar
        GameApp.ViewManager.Open(ViewType.LoadingView);

        // Asenkron operasyonu kullanarak sahneyi yükler
        asyncOperation = SceneManager.LoadSceneAsync(loadingModel.sceneName);

        // Yükleme tamamlandığında çağrılacak metodu belirler
        asyncOperation.completed += OnLoadedEndCallback;
        Debug.Log("LoadingView görünümü açıldı.");
    }

    // Yükleme tamamlandığında çağrılan metot
    private void OnLoadedEndCallback(AsyncOperation asyncOperation) {
        // Olayı temizler
        asyncOperation.completed -= OnLoadedEndCallback;

        // LoadingModel içindeki sahne geri çağrı metodu (callback) çağrılır
        GetModel<LoadingModel>().sceneCallback?.Invoke();

        // LoadingView'i kapatır
        GameApp.ViewManager.Close((int)ViewType.LoadingView);
        Debug.Log("LoadingView görünümü kapandı.");
    }
}
