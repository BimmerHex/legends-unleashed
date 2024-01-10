using UnityEngine;

// BaseModel sınıfından türetilmiş LoadingModel sınıfı
public class LoadingModel : BaseModel
{
    public string sceneName; // Yüklenmesi istenen sahnenin adı
    public System.Action sceneCallback; // Yükleme tamamlandığında çağrılacak geri çağrı metodu

    // LoadingModel sınıfının yapıcı metodu
    public LoadingModel() {
        
    }
}
