using System.Collections.Generic;

// Seviye verilerini temsil eden sınıf
public class LevelData
{
    public int id; // Seviye ID'si
    public string name; // Seviye adı
    public string sceneName; // Seviye sahnesinin adı
    public string description; // Seviye açıklaması
    public bool isFinish; // Seviyenin tamamlanıp tamamlanmadığını belirten durumu

    // Yapıcı metot: Seviye verilerini alarak bir LevelData örneği oluşturur
    public LevelData(Dictionary<string, string> data)
    {
        // Config dosyasındaki verileri kullanarak seviye özelliklerini doldurur
        id = int.Parse(data["Id"]);
        name = data["Name"];
        sceneName = data["SceneName"];
        description = data["Description"];
        isFinish = false; // Başlangıçta hiçbir seviye tamamlanmamış olarak işaretlenir
    }
}

// Seviye modelini temsil eden sınıf
public class LevelModel : BaseModel
{
    private ConfigData levelConfig; // Seviye konfigürasyonunu tutan değişken
    private Dictionary<int, LevelData> levels; // Seviyeleri tutan sözlük

    public LevelData currentLevel; // Şu anda seçili olan seviye

    // Yapıcı metot: LevelModel sınıfını başlatır
    public LevelModel()
    {
        levels = new Dictionary<int, LevelData>(); // Seviyeleri içeren sözlük oluşturulur
    }

    // BaseModel sınıfındaki soyut Init metodu uygulaması
    public override void Init()
    {
        // Seviye konfigürasyonunu al
        levelConfig = GameApp.ConfigManager.GetConfigData("Level");

        // Her bir satır için seviye verisi oluştur ve sözlüğe ekle
        foreach (var item in levelConfig.GetLines())
        {
            LevelData currentLevelData = new LevelData(item.Value);
            levels.Add(currentLevelData.id, currentLevelData);
        }
    }

    // Belirli bir ID'ye sahip seviyeyi getiren metot
    public LevelData GetLevel(int id)
    {
        return levels[id];
    }
}
