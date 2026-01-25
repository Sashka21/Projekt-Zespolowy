using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [Header("Audio Mixer")]
    public AudioMixer mixer; // ← przeciągniesz MainMixer w Inspectorze

    private AudioSource audioSource;
    private LoopSection loopSection;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            loopSection = GetComponent<LoopSection>();

            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Music
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SetVolume(music);

        // SFX
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float sfxDb = Mathf.Log10(Mathf.Clamp(sfx, 0.0001f, 1f)) * 20f;
        mixer.SetFloat("SFXVolume", sfxDb);
    }

    public void PlayMusic(AudioClip clip, float loopStart, float loopEnd)
    {
        if (clip == null) return;

        // 🔥 если уже играет этот трек — не перезапускать
        if (audioSource.clip == clip && audioSource.isPlaying)
            return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

        if (loopSection != null)
            loopSection.SetLoop(loopStart, loopEnd);
    }

    // 🔊 TERAZ sterujemy mixerem zamiast AudioSource
    public void SetVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;
        mixer.SetFloat("MusicVolume", dB);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
}
