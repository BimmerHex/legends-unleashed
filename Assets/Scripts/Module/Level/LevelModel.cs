using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int id;
    public string name;
    public string sceneName;
    public string description;
    public bool isFinish;

    public LevelData(Dictionary<string, string> data) {
        id = int.Parse(data["Id"]);
        name = data["Name"];
        sceneName = data["SceneName"];
        description = data["Description"];
        isFinish = false;
    }
}

public class LevelModel : BaseModel
{
    private ConfigData levelConfig;
    private Dictionary<int, LevelData> levels;

    public LevelData currentLevel;

    public LevelModel() {
        levels = new Dictionary<int, LevelData>();
    }

    public override void Init()
    {
        levelConfig = GameApp.ConfigManager.GetConfigData("Level");
        foreach (var item in levelConfig.GetLines())
        {
            LevelData currentLevelData = new LevelData(item.Value);
            levels.Add(currentLevelData.id, currentLevelData); 
        }
    }

    public LevelData GetLevel(int id) {
        return levels[id];
    }
}
