using UnityEngine;
using UnityEngine.UI;

// BaseView sınıfından türetilen SettingsView sınıfı
public class SettingsView : BaseView
{
    // Awake metodu üzerine yazılmış özel bir metot
    private protected override void OnAwake()
    {
        // BaseView sınıfının OnAwake metodunu çağır
        base.OnAwake();

        // "Background/Close" butonuna tıklanma olayına dinleyici eklenir ve OnCloseButton metodu atanır
        Find<Button>("Background/Close").onClick.AddListener(OnCloseButton);
        // "Background/Content/Mute" toggle değerini değiştirme olayına dinleyici eklenir ve OnIsMuteToggle metodu atanır
        Find<Toggle>("Background/Content/Mute").onValueChanged.AddListener(OnIsMuteToggle);
        // "Background/Content/Music Volume" sliderın değerini değiştirme olayına dinleyici eklenir ve OnMusicVolumeButton metodu atanır
        Find<Slider>("Background/Content/Music Volume").onValueChanged.AddListener(OnMusicVolumeButton);
        // "Background/Content/Slider Volume" sliderın değerini değiştirme olayına dinleyici eklenir ve OnEffectVolumeButton metodu atanır
        Find<Slider>("Background/Content/Effect Volume").onValueChanged.AddListener(OnEffectVolumeButton);

        // Kaydedilmiş ses ayarlarını yükle ve UI elemanlarını güncelle
        Find<Toggle>("Background/Content/Mute").isOn = GameApp.SoundManager.IsMuted;
        Find<Slider>("Background/Content/Music Volume").value = GameApp.SoundManager.MusicVolume;
        Find<Slider>("Background/Content/Effect Volume").value = GameApp.SoundManager.EffectVolume;
    }

    // "Background/Close" butonuna tıklandığında çağrılan metot
    private void OnCloseButton() {        
        GameApp.ViewManager.Close(ViewId); // View'ı kapatma işlevi çağrılır
        Debug.Log("SettingsView görünümü kapandı.");
    }

    // "Background/Content/Mute" toggle değerininin değiştirildiğinde çağrılan metot
    private void OnIsMuteToggle(bool isMute) {
        GameApp.SoundManager.IsMuted = isMute; // Sesin sessizlik durumunu güncelle
    }

    // "Background/Content/Music Volume" sliderının değerini değiştirdiğinde çağrılan metot
    private void OnMusicVolumeButton(float volume) {
        GameApp.SoundManager.MusicVolume = volume; // Müzik ses seviyesini güncelle
    }

    // "Background/Content/Slider Volume" sliderının değerini değiştirdiğinde çağrılan metot
    private void OnEffectVolumeButton(float volume) {
        GameApp.SoundManager.EffectVolume = volume; // Efekt ses seviyesini güncelle
    }    
}
