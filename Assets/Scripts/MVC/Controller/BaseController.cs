using System;
using System.Collections.Generic;
using UnityEngine;

// Temel Controller sınıfı
public class BaseController
{
    private Dictionary<string, Action<object[]>> _message; // Controller'a kayıtlı fonksiyonların bulunduğu sözlük
    private protected BaseModel _baseModel; // Controller'a bağlı BaseModel

    // BaseController'ın yapıcı metodu
    public BaseController() {
        _message = new Dictionary<string, Action<object[]>>();
    }

    // BaseController'ı başlatmak için kullanılan sanal metot
    public virtual void Init() {

    }

    // View yüklendiğinde çağrılan sanal metot
    public virtual void OnLoadView(IBaseView view) {

    }

    // View'ı açtığında çağrılan sanal metot
    public virtual void OpenView(IBaseView view) {

    }

    // View'ı kapattığında çağrılan sanal metot
    public virtual void CloseView(IBaseView view) {

    }

    // Belirtilen event'e bir fonksiyonu kayıt eden metot
    public void RegisterFunc(string eventName, Action<object[]> callback) {
        if (_message.ContainsKey(eventName)) {
            _message[eventName] += callback;
        } else {
            _message.Add(eventName, callback);
        }
    }

    // Belirtilen event'ten bir fonksiyonu kaldıran metot
    public void UnRegisterFunc(string eventName) {
        if (_message.ContainsKey(eventName)) {
            _message.Remove(eventName);
        }
    }

    // Belirtilen event'i çalıştıran metot
    public void ApplyFunc(string eventName, params object[] args) {
        if (_message.ContainsKey(eventName)) {
            _message[eventName].Invoke(args);
        } else {
            Debug.LogError($"Hata: {eventName} bulunmuyor!");
        }
    }

    // Belirtilen Controller'a ait bir event'i çalıştıran metot
    public void ApplyControllerFunc(int controllerKey, string eventName, params object[] args) {
        GameApp.ControllerManager.ApplyFunc(controllerKey, eventName, args);
    }

    // Belirtilen ControllerType'a ait bir event'i çalıştırmak için kullanılan metot
    public void ApplyControllerFunc(ControllerType controllerType, string eventName, params object[] args) {
        ApplyControllerFunc((int)controllerType, eventName, args);
    }
    
    // BaseModel'i Controller'a bağlamak için kullanılan metot
    public void SetModel(BaseModel model) {
        _baseModel = model;
        _baseModel.baseController = this;
    }

    // Controller'a bağlı BaseModel'i getiren metot
    public BaseModel GetModel() {
        return _baseModel;
    }

    // Belirtilen türdeki BaseModel'i getiren metot
    public T GetModel<T>() where T : BaseModel {
        return _baseModel as T;
    }

    // Controller'a bağlı BaseModel'i belirtilen controllerKey ile getiren metot
    public BaseModel GetControllerModel(int controllerKey) {
        return GameApp.ControllerManager.GetControllerModel(controllerKey);
    }

    // Controller'ı yok eden sanal metot
    public virtual void Destroy() {
        RemoveModuleEvent();
        RemoveGlobalEvent();
    }

    // Modül event'lerini başlatan sanal metot
    public virtual void InitModuleEvent() {

    }

    // Modül event'lerini kaldıran sanal metot
    public virtual void RemoveModuleEvent() {
        
    }

    // Global event'leri başlatan sanal metot
    public virtual void InitGlobalEvent() {

    }

    // Global event'leri kaldıran sanal metot
    public virtual void RemoveGlobalEvent() {

    }
}
