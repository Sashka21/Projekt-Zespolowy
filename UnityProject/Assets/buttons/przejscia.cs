using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // переход в меню настроек
    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("settingsmenu");
    }

    // переход в меню выбора машины
    public void LoadChooseCarMenu()
    {
        SceneManager.LoadScene("choose_a_car_menu");
    }
}
