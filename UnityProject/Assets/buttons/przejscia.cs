using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    private static Stack<string> sceneHistory = new Stack<string>();

    // uniwersalne przejście na scenę
    public void LoadScene(string sceneName)
    {
        sceneHistory.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

    // кнопка "Назад"
    public void GoBack()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop();
            SceneManager.LoadScene(previousScene);
        }
    }

    // --- METODY DLA PRZYCISKÓW ---

    public void LoadChooseCarMenu()
    {
        LoadScene("choose_a_car_menu");
    }

    public void LoadSettingsMenu()
    {
        LoadScene("settingsmenu");
    }

    public void LoadTorigra()
    {
        LoadScene("torigra");
    }
}
