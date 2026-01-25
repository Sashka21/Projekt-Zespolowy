using UnityEngine;

public class LoopSection : MonoBehaviour
{
    public AudioSource source;

    [Header("Loop settings (seconds)")]
    public float loopStart = 0f;
    public float loopEnd = 0f;

    void Update()
    {
        if (!source || !source.isPlaying) return;

        if (loopEnd > 0 && source.time >= loopEnd)
        {
            source.time = loopStart;
        }
    }

    public void SetLoop(float start, float end)
    {
        loopStart = start;
        loopEnd = end;
    }
}
