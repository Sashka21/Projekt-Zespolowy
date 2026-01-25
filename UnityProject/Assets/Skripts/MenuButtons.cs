using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Кнопка MAIN MENU
    public void MainMenu()
    {
        Debug.Log("MAIN MENU CLICKED");
        Time.timeScale = 1f;
        SceneManager.LoadScene("mega_pr");
    }

    // Кнопка REPLAY
    public void Replay()
    {
        Debug.Log("REPLAY CLICKED");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
