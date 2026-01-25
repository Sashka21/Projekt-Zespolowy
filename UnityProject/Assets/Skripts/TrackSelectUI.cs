using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSelectUI : MonoBehaviour
{
    public void SelectTrack(int trackID)
    {
        GameData.selectedTrack = trackID;
        SceneManager.LoadScene("SampleScene");
    }

    public void Back()
    {
        SceneManager.LoadScene("LapsSelect"); // якщо так називається сцена вибору машин
    }
}
