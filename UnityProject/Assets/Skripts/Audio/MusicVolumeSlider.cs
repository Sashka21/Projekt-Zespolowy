using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;
    private bool initialized = false;

    void Start()
    {
        slider = GetComponent<Slider>();

        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // ❗ сначала ставим значение
        slider.value = savedVolume;

        // ❗ только потом разрешаем реагировать
        initialized = true;

        slider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        if (!initialized) return;

        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(value);
        }

        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
}
