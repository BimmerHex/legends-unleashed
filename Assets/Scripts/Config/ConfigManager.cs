using System.Collections.Generic;
using UnityEngine;

// ConfigManager sınıfı, ConfigData sınıflarını yönetir ve kaynaklardan konfigürasyon dosyalarını yükler.
public class ConfigManager
{
    private Dictionary<string, ConfigData> _loadDatas; // Yüklenmeyi bekleyen konfigürasyon dosyalarını tutan sözlük
    private Dictionary<string, ConfigData> _configs; // Yüklenmiş konfigürasyon dosyalarını tutan sözlük

    // ConfigManager sınıfının yapıcı metodu
    public ConfigManager()
    {
        _loadDatas = new Dictionary<string, ConfigData>();
        _configs = new Dictionary<string, ConfigData>();
    }

    // Bir konfigürasyon dosyasını kayıt etmek için kullanılan metot
    public void Register(string txtFile, ConfigData config)
    {
        _loadDatas[txtFile] = config;
    }

    // Tüm konfigürasyon dosyalarını yüklemek için kullanılan metot
    public void LoadAllConfigs()
    {
        foreach (var item in _loadDatas)
        {
            TextAsset textAsset = item.Value.LoadFile();
            item.Value.Load(textAsset.text);
            _configs.Add(item.Value.fileName, item.Value);
        }

        _loadDatas.Clear();
    }

    // Belirli bir konfigürasyon dosyasını getiren metot
    public ConfigData GetConfigData(string txtFile)
    {
        if (_configs.ContainsKey(txtFile))
        {
            return _configs[txtFile];
        }
        else
        {
            return null;
        }
    }
}
