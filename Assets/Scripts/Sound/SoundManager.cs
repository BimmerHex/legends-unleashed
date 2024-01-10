using System.Collections.Generic;
using UnityEngine;

// Ses yönetimini sağlayan sınıf
public class SoundManager
{
    private AudioSource bgmSource; // Arkaplan müziği için kullanılan ses kaynağı
    private Dictionary<string, AudioClip> _clips; // Ses efektleri için kullanılan ses dosyalarının sözlüğü
    private bool isMuted;
    private float musicVolume;
    private float effectVolume;

    public bool IsMuted {
        get { return isMuted; }
        set {
            isMuted = value;
            if (isMuted) bgmSource.Pause();
            else bgmSource.Play();
        }
    }

    public float MusicVolume {
        get { return musicVolume; }
        set {
            musicVolume = value;
            bgmSource.volume = musicVolume;
        }
    }

    public float EffectVolume {
        get { return effectVolume; }
        set { effectVolume = value; }
    }

    // SoundManager sınıfının yapıcı metodu
    public SoundManager() {
        _clips = new Dictionary<string, AudioClip>(); // Ses dosyalarını tutan sözlüğü oluştur
        bgmSource = GameObject.Find("Game").GetComponent<AudioSource>(); // Arkaplan müziği ses kaynağını Game objesinden al
        isMuted = false;
        musicVolume = 1f;
        effectVolume = 1f;
    }

    // Arkaplan müziği çalmak için kullanılan metot
    public void PlayBGM(string res) {
        if (isMuted) return;

        if (!_clips.ContainsKey(res))
        {
            AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}"); // Belirtilen isimdeki ses dosyasını yükle
            _clips.Add(res, clip); // Sözlüğe ekle
        }

        bgmSource.clip = _clips[res]; // Arkaplan müziğini belirlenen ses dosyasıyla güncelle
        bgmSource.Play(); // Arkaplan müziğini çal
        Debug.Log("SoundManager sınıfındaki PlayBGM metodu çalıştırıldı.");
    }
}
