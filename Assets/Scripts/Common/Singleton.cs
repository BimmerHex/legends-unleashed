using System;

// Generic Singleton sınıfı
public class Singleton<T>
{
    // Yalnızca bir örnek oluşturulmasını sağlamak için Activator.CreateInstance kullanılır
    private static readonly T instance = Activator.CreateInstance<T>();

    // Yalnızca bir örnek erişimi sağlayan özellik
    public static T Instance {
        get {
            return instance;
        }
    }

    // Sınıfın başlatılması için kullanılabilecek sanal metot
    public virtual void Init() {

    }

    // Sınıfın güncellenmesi için kullanılabilecek sanal metot
    public virtual void Update(float dt) {

    }

    // Sınıfın yok edilmesi için kullanılabilecek sanal metot
    public virtual void OnDestroy() {

    }
}
