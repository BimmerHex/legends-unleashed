using System.Collections.Generic;
using UnityEngine;

// BaseView sınıfı, MonoBehaviour ve IBaseView arayüzünü uygular
public class BaseView : MonoBehaviour, IBaseView
{
    // Görünümün benzersiz kimliği
    public int ViewId { get; set; }

    // Görünümün bağlı olduğu BaseController
    public BaseController BaseController { get; set; }

    // Görünümün Canvas bileşeni
    private protected Canvas _canvas;

    // Görünümde kullanılan GameObject'leri önbellekte tutan sözlük
    private protected Dictionary<string, GameObject> _cacheGameObject = new Dictionary<string, GameObject>();

    // Görünümün başlatılıp başlatılmadığını belirten bayrak
    private bool isInit = false;

    // Awake metodu, Unity tarafından nesne oluşturulduğunda çağrılır
    private void Awake() {
        // Canvas bileşenini al
        _canvas = gameObject.GetComponent<Canvas>();

        // Türetilmiş sınıfların Awake metodunu çağır
        OnAwake();
    }

    // Start metodu, Unity tarafından ilk çerçeve güncellemesinden önce çağrılır
    private void Start() {
        // Türetilmiş sınıfların Start metodunu çağır
        OnStart();
    }

    // Türetilmiş sınıfların Awake metodunu çağırmak için kullanılan sanal metot
    private protected virtual void OnAwake() {

    }

    // Türetilmiş sınıfların Start metodunu çağırmak için kullanılan sanal metot
    private protected virtual void OnStart() {
        
    }

    // Belirtilen Controller ve event'e ait fonksiyonu çağırma metodu
    public void ApplyControllerFunc(int controllerKey, string eventName, params object[] args) {
        BaseController.ApplyControllerFunc(controllerKey, eventName, args);
    }

    // Belirtilen event'e ait fonksiyonu çağırma metodu
    public void ApplyFunc(string eventName, params object[] args) {
        BaseController.ApplyFunc(eventName, args);
    }

    // Görünümü kapatma metodu
    public virtual void Close(params object[] args) {
        SetVisible(false);
    }

    // Görünümü yok etme metodu
    public void DestroyView() {
        // BaseController referansını null yap ve GameObject'i yok et
        BaseController = null;
        Destroy(gameObject);
    }

    // Görünüm verilerini başlatma metodu
    public virtual void InitData() {
        // Görünüm verilerinin başlatıldığını işaretle
        isInit = true;
    }

    // Görünüm UI elemanlarını başlatma metodu
    public virtual void InitUI() {
        
    }

    // Görünümün başlatılıp başlatılmadığını kontrol etme metodu
    public bool IsInit() {
        return isInit;
    }

    // Görünümün görünüp görünmediğini kontrol etme metodu
    public bool IsShow() {
        return _canvas.enabled == true;
    }

    // Görünümü açma metodu
    public virtual void Open(params object[] args) {
        
    }

    // Görünümün görünürlüğünü ayarlama metodu
    public void SetVisible(bool value) {
        _canvas.enabled = value;
    }

    // Belirtilen isme sahip GameObject'i bulma metodu
    public GameObject Find(string res) {
        if (_cacheGameObject.ContainsKey(res)) {
            return _cacheGameObject[res];
        }

        // Belirtilen isme sahip GameObject'i bul ve önbelleğe ekle
        _cacheGameObject.Add(res, transform.Find(res).gameObject);
        return _cacheGameObject[res];
    }

    // Belirtilen isme sahip GameObject'in belirtilen bileşen türünü bulma metodu
    public T Find<T>(string res) where T : Component {
        GameObject obj = Find(res);
        return obj.GetComponent<T>();
    }
}
