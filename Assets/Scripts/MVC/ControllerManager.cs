using System.Collections.Generic;
using System.Linq;

// Controller'ların yönetildiği sınıf
public class ControllerManager
{
    private Dictionary<int, BaseController> _modules; // Controller'ların depolandığı sözlük

    // ControllerManager'ın yapıcı metodu
    public ControllerManager() {
        _modules = new Dictionary<int, BaseController>();
    }

    // Controller'ı kaydetmek için kullanılan metot
    public void Register(int controllerKey, BaseController controller) {
        if (!_modules.ContainsKey(controllerKey)) {
            _modules.Add(controllerKey, controller);
        }
    }

    // Controller'ı belirtilen ControllerType'a kaydetmek için kullanılan metot
    public void Register(ControllerType controllerType, BaseController controller) {
        Register((int)controllerType, controller);
    }

    // Controller'ları başlatmak için kullanılan metot
    public void InitAllModules() {
        foreach (var item in _modules)
        {
            item.Value.Init();
        }
    }

    // Controller'ı kayıttan kaldırmak için kullanılan metot
    public void UnRegister(int controllerKey) {
        if (_modules.ContainsKey(controllerKey)) {
            _modules.Remove(controllerKey);
        }
    }

    // Tüm Controller'ları temizlemek için kullanılan metot
    public void Clear() {
        _modules.Clear();
    }

    // Tüm modüllerin Controller'larını yok etmek için kullanılan metot
    public void ClearAllModules() {
        List<int> keys = _modules.Keys.ToList();

        for (int i = 0; i < keys.Count; i++) {
            _modules[keys[i]].Destroy();
            _modules.Remove(keys[i]);
        }
    }

    // Belirtilen Controller'a ait bir event'i çalıştırmak için kullanılan metot
    public void ApplyFunc(int controllerKey, string eventName, System.Object[] args) {
        if (_modules.ContainsKey(controllerKey)) {
            _modules[controllerKey].ApplyFunc(eventName, args);
        }
    }

    // Belirtilen Controller'a ait Model'i getirmek için kullanılan metot
    public BaseModel GetControllerModel(int controllerKey) {
        if (_modules.ContainsKey(controllerKey)) {
            return _modules[controllerKey].GetModel();
        } else {
            return null;
        }
    }
}
