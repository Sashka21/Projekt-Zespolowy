using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject[] tracks;

    void Start()
    {
        if (tracks == null || tracks.Length == 0)
        {
            Debug.LogError("TrackManager: tracks array is empty!");
            return;
        }

        int index = GameData.selectedTrack;

        if (index < 0 || index >= tracks.Length)
        {
            Debug.LogWarning($"Track index {index} out of range. Using 0 instead.");
            index = 0;
        }

        Instantiate(tracks[index], Vector3.zero, Quaternion.identity);
    }

}
