using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceTimerUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI lapText;

    [Header("Race info")]
    [SerializeField] private string playerName = "Player";
    [SerializeField] private int totalLaps = 3;

    private float startTime;
    private bool running;

    private int currentLap = 0;

    private void Awake()
    {
        playerNameText.text = playerName;
        UpdateLapText();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

    public void SetLap(int lap)
    {
        currentLap = lap;
        UpdateLapText();
    }

    private void Update()
    {
        if (!running) return;

        float elapsed = Time.time - startTime;
        timerText.text = "Time: " + FormatTime(elapsed);
    }

    private void UpdateLapText()
    {
        lapText.text = $"Lap: {currentLap} / {totalLaps}";
    }

    private string FormatTime(float t)
    {
        int min = Mathf.FloorToInt(t / 60f);
        float sec = t % 60f;
        return $"{min:00}:{sec:00.00}";
    }
}