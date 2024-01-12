using UnityEngine;

// ChallengeController sınıfı, ChallengeView'in kontrolünü sağlar.
public class ChallengeController : BaseController
{
    // ChallengeController sınıfının yapıcı metodu
    public ChallengeController() : base()
    {
        // ChallengeView'i kayıt et
        GameApp.ViewManager.Register(ViewType.ChallengeView, new ViewInfo()
        {
            prefabName = "ChallengeView", // ChallengeView prefab adı
            baseController = this, // Bu controller'a referans
            parentTransform = GameApp.ViewManager.canvasTransform // UI elemanlarının ekleneceği parent transform
        });

        // Modül event'lerini başlat
        InitModuleEvent();
    }

    // Modül event'lerini başlatan metot
    public override void InitModuleEvent()
    {
        // OpenChallengeView metodu, Defines.OpenChallengeView event'i ile ilişkilendirilir
        RegisterFunc(Defines.OpenChallengeView, OpenChallengeView);
    }

    // OpenChallengeView metodu, Defines.OpenChallengeView event'i çağrıldığında çalışır
    private void OpenChallengeView(System.Object[] args)
    {
        // ChallengeView'i aç
        GameApp.ViewManager.Open(ViewType.ChallengeView);
        Debug.Log("OpenChallengeView görünümü açıldı.");
    }
}
