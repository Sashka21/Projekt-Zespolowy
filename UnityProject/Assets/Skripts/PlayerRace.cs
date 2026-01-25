using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerRace : MonoBehaviour
{
    [SerializeField] private RaceTimerUI raceTimer;
    [SerializeField] private RaceManager raceManager;

    public RaceManager RaceManager => raceManager;

    [Header("Identity")]
    public string playerName = "Player";

    [Header("Race settings")]
    public int totalCheckpointsPerLap = 0; // set by RaceManager

    // runtime
    public int nextCheckpointIndex = 0;
    public int completedLaps = 0;
    public bool IsFinished { get; private set; } = false;
    public float finishTime { get; private set; }

    private bool allCheckpointsPassed = false;

    // called from Checkpoint when player crosses a checkpoint trigger
    public void PassCheckpoint(int index)
    {
        if (IsFinished) return;

        if (index != nextCheckpointIndex)
            return;

        nextCheckpointIndex++;

        if (nextCheckpointIndex >= totalCheckpointsPerLap)
        {
            nextCheckpointIndex = 0;
            allCheckpointsPassed = true;
            Debug.Log($"{playerName} passed all checkpoints for the lap.");
        }
        else
        {
            Debug.Log($"{playerName} passed checkpoint {index}, next {nextCheckpointIndex}");
        }
    }

    private void Start()
    {
        if (raceTimer != null)
            raceTimer.Init(this);
    }

    // called by FinishLineTrigger
    public void TryFinish()
{
    if (IsFinished) return;

    if (allCheckpointsPassed)
    {
        completedLaps++;
        nextCheckpointIndex = 0;
        allCheckpointsPassed = false;

        Debug.Log($"{playerName} completed lap {completedLaps}/{RaceManager.totalLaps}");

        if (completedLaps >= RaceManager.totalLaps)
        {
            Finish();
        }
    }
}
private void Finish()
{
    if (IsFinished) return;

    IsFinished = true;
    finishTime = Time.time;

    if (raceManager != null)
        raceManager.PlayerFinished(this);

    raceTimer?.StopTimer();
}


    // optional for restart
    public void ResetRaceState()
    {
        nextCheckpointIndex = 0;
        completedLaps = 0;
        IsFinished = false;
        finishTime = 0f;
        allCheckpointsPassed = false;
    }
}
