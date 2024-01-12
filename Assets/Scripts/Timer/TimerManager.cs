public class TimerManager
{
    private GameTimer gameTimer; // Oyun içindeki zamanlayıcıları yöneten GameTimer nesnesi

    // TimerManager sınıfının yapıcı metodu
    public TimerManager() {
        gameTimer = new GameTimer();
    }

    // Yeni bir zamanlayıcı kaydeder
    public void Register(float timer, System.Action callback) {
        gameTimer.Register(timer, callback);
    }

    // Zamanlayıcıları günceller
    public void OnUpdate(float dt) {
        gameTimer.OnUpdate(dt);
    }
}
