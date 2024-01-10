using TMPro;
using UnityEngine.UI;

// Mesajın temel bilgilerini içeren sınıf
public class MessageInfo
{
    public string messageText; // Mesaj metni
    public System.Action acceptCallBack; // Kabul (Accept) butonuna tıklanınca çağrılacak metot
    public System.Action cancelCallBack; // İptal (Cancel) butonuna tıklanınca çağrılacak metot
}

// BaseView sınıfından türetilen MessageView sınıfı
public class MessageView : BaseView
{
    private MessageInfo messageInfo; // Mesaj bilgilerini tutan özel bir değişken

    // Awake metodu üzerine yazılmış özel bir metot
    private protected override void OnAwake()
    {
        // BaseView sınıfının OnAwake metodunu çağır
        base.OnAwake();
        
        // "Accept" butonuna tıklanma olayına dinleyici eklenir ve OnAcceptButton metodu atanır
        Find<Button>("Accept").onClick.AddListener(OnAcceptButton);
        // "Cancel" butonuna tıklanma olayına dinleyici eklenir ve OnCancelButton metodu atanır
        Find<Button>("Cancel").onClick.AddListener(OnCancelButton);
    }

    // BaseView sınıfındaki Open metodu üzerine yazılmış özel bir metot
    public override void Open(params object[] args)
    {
        // Gelen argümanları MessageInfo tipine dönüştürerek messageInfo değişkenine atar
        messageInfo = args[0] as MessageInfo;
        // MessageView içindeki "Info/Text" nesnesinin metin özelliğine gelen mesaj metnini atar
        Find<TextMeshProUGUI>("Info/Text").text = messageInfo.messageText;
    }

    // "Accept" butonuna tıklandığında çağrılan metot
    private void OnAcceptButton() {
        // Eğer acceptCallBack metodu atanmışsa çağrılır, aksi takdirde hiçbir şey yapmaz
        messageInfo.acceptCallBack?.Invoke();
    }

    // "Cancel" butonuna tıklandığında çağrılan metot
    private void OnCancelButton() {
        // Eğer cancelCallBack metodu atanmışsa çağrılır, aksi takdirde hiçbir şey yapmaz
        messageInfo.cancelCallBack?.Invoke();
        // View'ı kapatma işlevi çağrılır
        GameApp.ViewManager.Close(ViewId);
    }
}
