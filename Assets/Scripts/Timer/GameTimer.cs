using System.Collections.Generic;

public class GameTimer
{
    private List<GameTimerData> gameTimerDatas; // Zamanlayıcı verilerini içeren liste

    // GameTimer sınıfının yapıcı metodu
    public GameTimer() {
        gameTimerDatas = new List<GameTimerData>();
    }

    // Yeni bir zamanlayıcı kaydeder
    public void Register(float timer, System.Action callback) {
        GameTimerData gameTimerData = new GameTimerData(timer, callback);
        gameTimerDatas.Add(gameTimerData);
    }

    // Tüm zamanlayıcıları günceller ve süresi dolduysa listeden kaldırır
    public void OnUpdate(float dt) {
        for (int i = gameTimerDatas.Count - 1; i >= 0; i--) {
            if (gameTimerDatas[i].OnUpdate(dt)) {
                gameTimerDatas.RemoveAt(i);
            }
        }
    }

    // Tüm zamanlayıcıları temizler
    public void Break() {
        gameTimerDatas.Clear();
    }

    // Zamanlayıcı sayısını döndürür
    public int Count() {
        return gameTimerDatas.Count;
    }
}
