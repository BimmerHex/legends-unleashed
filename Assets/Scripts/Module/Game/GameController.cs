// BaseController sınıfından türetilen GameController sınıfı
public class GameController : BaseController
{
    // GameController'ın yapıcı metodu
    public GameController() : base() {
        // Modül event'lerini ve global event'leri başlat
        InitModuleEvent();
        InitGlobalEvent();
    }

    // BaseController sınıfından miras alınan sanal metot, Controller'ın başlatılmasını sağlar
    public override void Init()
    {
        // GameUI Controller'a ait OpenStartView event'ini çağır
        ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
    }
}
