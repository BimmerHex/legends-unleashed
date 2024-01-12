using UnityEngine;

// PlayerController sınıfı, oyuncu kontrolünü sağlar.
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.5f;
    [SerializeField] private Animator anim;

    // Start metodu, nesne oluşturulduğunda çağrılır
    private void Start()
    {
        // Animator bileşenini al
        anim = GetComponent<Animator>();
        // Kameranın pozisyonunu oyuncunun pozisyonuna ayarla
        GameApp.CameraManager.SetPos(transform.position);
    }

    // Update metodu, her bir frame'de çağrılır
    private void Update()
    {
        // Klavyeden yatay girişi al
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Eğer oyuncu hareket etmiyorsa, Idle animasyonunu oynat
        if (horizontal == 0)
        {
            anim.Play("Idle");
        }
        else
        {
            // Oyuncu sağa gidiyorsa ve karakter ters dönükse veya sola gidiyorsa ve karakter düz duruyorsa, karakteri çevir
            if ((horizontal > 0 && transform.localScale.x < 0) || (horizontal < 0 && transform.localScale.x > 0))
            {
                Flip();
            }

            // Yatay hareketi kullanarak yeni pozisyonu hesapla
            Vector3 position = transform.position + Vector3.right * horizontal * moveSpeed * Time.deltaTime;
            
            // Pozisyonu belirli bir aralıkta tut
            position.x = Mathf.Clamp(position.x, -4, 34);
            
            // Oyuncu pozisyonunu güncelle
            transform.position = position;
            
            // Kameranın pozisyonunu oyuncunun pozisyonuna eşitle
            GameApp.CameraManager.SetPos(transform.position);
            
            // Hareket animasyonunu oynat
            anim.Play("Move");
        }
    }

    // Karakteri çeviren metot
    public void Flip()
    {
        // Karakterin ölçeğini tersine çevir
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
