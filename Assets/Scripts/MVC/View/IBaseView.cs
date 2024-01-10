using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Temel View arayüzü
public interface IBaseView
{
    bool IsInit(); // View'ın başlatılıp başlatılmadığını kontrol eden metot
    bool IsShow(); // View'ın görüntülenip görüntülenmediğini kontrol eden metot
    void InitUI(); // UI'nin başlatılmasını sağlayan metot
    void InitData(); // Verilerin başlatılmasını sağlayan metot
    void Open(params object[] args); // View'ı açan metot
    void Close(params object[] args); // View'ı kapatan metot
    void DestroyView(); // View'ı yok eden metot
    void ApplyFunc(string eventName, params object[] args); // Belirtilen fonksiyonu uygulayan metot
    void ApplyControllerFunc(int controllerKey, string eventName, params object[] args); // Controller üzerinde belirtilen fonksiyonu uygulayan metot
    void SetVisible(bool value); // View'ın görünürlüğünü ayarlayan metot
    int ViewId { get; set; } // View'ın benzersiz kimliği
    BaseController BaseController { get; set; } // View'a bağlı BaseController
}
