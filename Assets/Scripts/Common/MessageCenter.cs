using System.Collections.Generic;

// MessageCenter sınıfı, iletişim ve oyun içi olayları yönetir.
public class MessageCenter
{
    private Dictionary<string, System.Action<object>> _message;
    private Dictionary<string, System.Action<object>> _tempMessage;
    private Dictionary<System.Object, Dictionary<string, System.Action<object>>> _objectMessage;

    public MessageCenter() {
        _message = new Dictionary<string, System.Action<object>>();
        _tempMessage = new Dictionary<string, System.Action<object>>();
        _objectMessage = new Dictionary<object, Dictionary<string, System.Action<object>>>();
    }

    // Belirtilen event'e bir fonksiyonu kayıt eden metot
    public void AddEvent(string eventName, System.Action<object> callback) {
        if (_message.ContainsKey(eventName)) {
            _message[eventName] += callback;
        } else {
            _message.Add(eventName, callback);
        }
    }

    // Belirtilen event'ten bir fonksiyonu kaldıran metot
    public void RemoveEvent(string eventName, System.Action<object> callback) {
        if (_message.ContainsKey(eventName)) {
            _message[eventName] -= callback;
            if (_message[eventName] == null) {
                _message.Remove(eventName);
            }
        }
    }

    // Belirtilen event'i çalıştıran metot
    public void PostEvent(string eventName, object arg = null) {
        if (_message.ContainsKey(eventName)) {
            _message[eventName].Invoke(arg);
        }
    }

    // Belirtilen nesneye ve event'e bir fonksiyonu kayıt eden metot
    public void AddEvent(System.Object listenerObject, string eventName, System.Action<object> callback) {
        if (_objectMessage.ContainsKey(listenerObject)) {
            if (_objectMessage[listenerObject].ContainsKey(eventName)) {
                _objectMessage[listenerObject][eventName] += callback;
            } else {
                _objectMessage[listenerObject].Add(eventName, callback);
            }
        } else {
            Dictionary<string, System.Action<object>> _tempObjectMessage = new Dictionary<string, System.Action<object>>();
            _tempObjectMessage.Add(eventName, callback);
            _objectMessage.Add(listenerObject, _tempObjectMessage);
        }
    }

    // Belirtilen nesneye ve event'ten bir fonksiyonu kaldıran metot
    public void RemoveEvent(System.Object listenerObject, string eventName, System.Action<object> callback) {
        if (_objectMessage.ContainsKey(listenerObject)) {
            if (_objectMessage[listenerObject].ContainsKey(eventName)) {
                _objectMessage[listenerObject][eventName] -= callback;
                if (_objectMessage[listenerObject][eventName] == null) {
                    _objectMessage[listenerObject].Remove(eventName);
                    if (_objectMessage[listenerObject].Count == 0) {
                        _objectMessage.Remove(listenerObject);
                    }
                }
            }
        }
    }

    // Belirtilen nesnenin tüm event'lerini kaldıran metot
    public void RemoveObjectAllEvent(System.Object listenerObject) {
        if (_objectMessage.ContainsKey(listenerObject)) {
            _objectMessage.Remove(listenerObject);
        }
    }

    // Belirtilen nesneye ve event'i çalıştıran metot
    public void PostEvent(System.Object listenerObject, string eventName, System.Object arg = null) {
        if (_objectMessage.ContainsKey(listenerObject)) {
            if (_objectMessage[listenerObject].ContainsKey(eventName)) {
                _objectMessage[listenerObject][eventName].Invoke(arg);
            }
        }
    }

    // Geçici bir event'e bir fonksiyonu kayıt eden metot
    public void AddTempEvent(string eventName, System.Action<object> callback) {
        if (_tempMessage.ContainsKey(eventName)) {
            _tempMessage[eventName] += callback;
        } else {
            _tempMessage.Add(eventName, callback);
        }
    }

    // Geçici bir event'i çalıştıran metot
    public void PostTempEvent(string eventName, System.Object arg = null) {
        if (_tempMessage.ContainsKey(eventName)) {
            _tempMessage[eventName].Invoke(arg);
            _tempMessage[eventName] = null;
            _tempMessage.Remove(eventName);
        }
    }
}
