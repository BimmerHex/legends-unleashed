public class GameTimerData
{
    private float timer; // Zamanlayıcı süresi
    private System.Action callback; // Zamanlayıcı süresi dolduğunda çağrılacak olan callback metodu
    
    // GameTimerData sınıfının yapıcı metodu
    public GameTimerData(float timer, System.Action callback) {
        this.timer = timer;
        this.callback = callback;
    }

    // Belirli bir süre geçtikten sonra çağrılan metot
    public bool OnUpdate(float dt) {
        timer -= dt;
        if (timer <= 0) {
            this.callback.Invoke();
            return true;
        }

        return false;
    }
}
