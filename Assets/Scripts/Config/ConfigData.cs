using System.Collections.Generic;
using UnityEngine;

// ConfigData sınıfı, bir konfigürasyon dosyasını temsil eder ve bu dosyadan veri çekme işlemlerini gerçekleştirir.
public class ConfigData
{
    private Dictionary<int, Dictionary<string, string>> _datas; // Verilerin depolandığı sözlük
    public string fileName; // Dosya adını tutan değişken

    // ConfigData sınıfının yapıcı metodu
    public ConfigData(string fileName)
    {
        this.fileName = fileName;
        this._datas = new Dictionary<int, Dictionary<string, string>>();
    }

    // Kaynaklardan belirli bir metin dosyasını yüklemek için kullanılan metot
    public TextAsset LoadFile()
    {
        return Resources.Load<TextAsset>($"Data/{fileName}");
    }

    // Metin dosyasındaki verileri yüklemek için kullanılan metot
    public void Load(string txtFile)
    {
        string[] datas = txtFile.Split("\n");
        string[] titles = datas[0].Trim().Split(",");

        for (int i = 1; i < datas.Length; i++)
        {
            string[] tempArray = datas[i].Trim().Split(',');
            Dictionary<string, string> tempData = new Dictionary<string, string>();

            for (int j = 0; j < tempArray.Length; j++)
            {
                tempData.Add(titles[j], tempArray[j]);
            }

            _datas.Add(int.Parse(tempData["Id"]), tempData);
        }
    }

    // Belirli bir ID'ye sahip veriyi getiren metot
    public Dictionary<string, string> GetDataById(int id)
    {
        if (_datas.ContainsKey(id))
        {
            return _datas[id];
        }

        return null;
    }

    // Tüm veriyi içeren sözlüğü getiren metot
    public Dictionary<int, Dictionary<string, string>> GetLines()
    {
        return _datas;
    }
}
