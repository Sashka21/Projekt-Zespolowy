using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SFXVolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        slider.onValueChanged.AddListener(OnChanged);
    }

    void OnChanged(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mixer.SetFloat("SFXVolume", dB);

        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}