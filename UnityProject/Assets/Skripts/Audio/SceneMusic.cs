using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip music;
    public float loopStart;
    public float loopEnd;

    void Start()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayMusic(music, loopStart, loopEnd);
        }
    }
}
