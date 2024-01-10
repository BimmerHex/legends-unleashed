using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Görünümleri yöneten sınıf
public class ViewInfo
{
    // Görünüm prefab adı
    public string prefabName;

    // Görünümün parent'ı
    public Transform parentTransform;

    // Görünümün bağlı olduğu Controller
    public BaseController baseController;

    public int sortingOrder;
}

// Görünüm yöneticisi sınıfı
public class ViewManager
{
    // Açık olan görünümleri saklayan sözlük
    private Dictionary<int, IBaseView> _opens;

    // Önbellekteki görünümleri saklayan sözlük
    private Dictionary<int, IBaseView> _viewCache;

    // Tüm görünümleri saklayan sözlük
    private Dictionary<int, ViewInfo> _views;

    // UI elemanlarını içeren Canvas
    public Transform canvasTransform;

    // Dünya koordinatlarındaki UI elemanlarını içeren Canvas
    public Transform worldCanvasTransform;

    // ViewManager'ın yapıcı metodu
    public ViewManager() {
        // Canvas ve World Canvas bulunuyor mu?
        canvasTransform = GameObject.Find("Canvas").transform;
        worldCanvasTransform = GameObject.Find("World Canvas").transform;

        // Açık olan, önbellekteki ve tüm görünümleri saklayan sözlükleri başlat
        _opens = new Dictionary<int, IBaseView>();
        _views = new Dictionary<int, ViewInfo>();
        _viewCache = new Dictionary<int, IBaseView>();
    }

    // Görünüm kaydı yapmak için kullanılan metot
    public void Register(int key, ViewInfo viewInfo) {
        if (!_views.ContainsKey(key)) {
            _views.Add(key, viewInfo);
        }
    }

    // Görünüm kaydı yapmak için kullanılan metot (ViewType enum'u ile)
    public void Register(ViewType viewType, ViewInfo viewInfo) {
        Register((int)viewType, viewInfo);
    }

    // Görünüm kaydını kaldırmak için kullanılan metot
    public void UnRegister(int key) {
        if (_viewCache.ContainsKey(key)) {
            _views.Remove(key);
        }
    }

    // Görünümü kaldırmak için kullanılan metot
    public void RemoveView(int key) {
        _views.Remove(key);
        _viewCache.Remove(key);
        _opens.Remove(key);
    }

    // Belirtilen Controller'a ait görünümleri kaldırmak için kullanılan metot
    public void RemoveViewByController(BaseController controller) {
        foreach (var item in _views)
        {
            if (item.Value.baseController == controller) {
                RemoveView(item.Key);
            }
        }
    }

    // Belirtilen görünüm açık mı?
    public bool IsOpen(int key) {
        return _opens.ContainsKey(key);
    }

    // Belirtilen key'e ait görünümü getir
    public IBaseView GetView(int key) {
        if (_opens.ContainsKey(key)) {
            return _opens[key];
        }

        if (_viewCache.ContainsKey(key)) {
            return _viewCache[key];
        }

        return null;
    }

    // Belirtilen key'e ait görünümü belirli bir türde getir
    public T GetView<T>(int key) where T : class, IBaseView {
        IBaseView view = GetView(key);
        if (view != null) {
            return view as T;
        }

        return null;
    }

    // Belirtilen key'e ait görünümü yok et
    public void Destroy(int key) {
        IBaseView oldView = GetView(key);
        if (oldView != null) {
            UnRegister(key);
            oldView.DestroyView();
            _viewCache.Remove(key);
        }
    }

    // Belirtilen key'e ait görünümü kapat
    public void Close(int key, params object[] args) {
        if (!IsOpen(key)) {
            return;
        }

        IBaseView view = GetView(key);
        if (view != null) {
            _opens.Remove(key);
            view.Close(args);
            _views[key].baseController.CloseView(view);
        }
    }

    // Belirtilen key'e ait görünümü aç
    public void Open(int key, params object[] args) {
        IBaseView view = GetView(key);
        ViewInfo viewInfo = _views[key];
        if (view == null) {
            // Görünüm yoksa oluştur ve aç
            string viewType = ((ViewType)key).ToString();
            GameObject uiObj = UnityEngine.Object.Instantiate(Resources.Load($"View/{viewInfo.prefabName}"), viewInfo.parentTransform) as GameObject;
            Canvas canvas = uiObj.GetComponent<Canvas>();
            if (canvas == null) {
                canvas = uiObj.AddComponent<Canvas>();
            }
            if (uiObj.GetComponent<GraphicRaycaster>() == null) {
                uiObj.AddComponent<GraphicRaycaster>();
            }
            canvas.overrideSorting = true;
            canvas.sortingOrder = viewInfo.sortingOrder;
            view = uiObj.AddComponent(Type.GetType(viewType)) as IBaseView;
            view.ViewId = key;
            view.BaseController = viewInfo.baseController;
            _viewCache.Add(key, view);
            viewInfo.baseController.OnLoadView(view);
        }

        if (_opens.ContainsKey(key)) {
            return;
        }

        // Açık görünümleri listeye ekle ve görünümü aç
        _opens.Add(key, view);

        if (view.IsInit()) {
            view.SetVisible(true);
            view.Open(args);
            viewInfo.baseController.OpenView(view);
        } else {
            view.InitUI();
            view.InitData();
            view.Open(args);
            viewInfo.baseController.OpenView(view);
        }
    }

    // ViewType enum'u ile belirtilen görünümü açma
    public void Open(ViewType viewType, params object[] args) {
        Open((int)viewType, args);
    }
}
