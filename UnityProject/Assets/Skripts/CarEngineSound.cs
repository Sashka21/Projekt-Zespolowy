using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Player))]
public class CarEngineSound2D : MonoBehaviour
{
    public AudioClip engineIdle;
    public AudioClip engineAccelerate;
    public AudioClip engineDecelerate;

    public float minSpeedForMove = 0.1f;

    private AudioSource audioSource;
    private Player player;



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();

        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        Play(engineIdle);
    }

    void Update()
    {
        float speed = player.CurrentSpeed;

        if (speed < minSpeedForMove)
        {
            Play(engineIdle);
        }
        else if (player.IsAccelerating)
        {
            Play(engineAccelerate);
        }
        else if (player.IsBraking)
        {
            Play(engineDecelerate);
        }
        else
        {
            Play(engineIdle);
        }

        // Pitch = prêdkoœæ (opcjonalne, ale POLECAM)
        audioSource.pitch = Mathf.Lerp(0.9f, 1.3f, speed / maxSpeedForPitch);
    }

    public float maxSpeedForPitch = 5f;

    void Play(AudioClip clip)
    {
        if (clip == null) return;
        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.Play();
    }
}
