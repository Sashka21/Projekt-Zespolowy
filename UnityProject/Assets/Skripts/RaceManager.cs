using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    [Header("Race Settings")]
    public int totalLaps;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TMP_Text player1Text;
    public TMP_Text player2Text;

    public bool RaceFinished { get; private set; } = false;

    private List<PlayerRace> players = new List<PlayerRace>();
    private List<PlayerRace> finishedPlayers = new List<PlayerRace>();

    private IEnumerator Start()
    {
        yield return null;
        totalLaps = GameData.laps;

        players.Clear();
        players.AddRange(FindObjectsOfType<PlayerRace>());

        foreach (var p in players)
        {
            p.totalCheckpointsPerLap = FindTotalCheckpoints();
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        RaceFinished = false;

        Debug.Log("RaceManager: players = " + players.Count);
    }

    int FindTotalCheckpoints()
    {
        Checkpoint[] cps = FindObjectsOfType<Checkpoint>();
        int maxIndex = -1;

        foreach (var cp in cps)
            if (cp.index > maxIndex)
                maxIndex = cp.index;

        return maxIndex + 1;
    }

    // викликається з PlayerRace коли гравець закінчив всі кола
    public void PlayerFinished(PlayerRace player)
    {
        if (RaceFinished) return;

        Debug.Log("PlayerFinished: " + player.playerName);

        if (!finishedPlayers.Contains(player))
            finishedPlayers.Add(player);

        if (finishedPlayers.Count >= players.Count)
        {
            RaceFinished = true;
            ShowResults();
        }
    }

    void ShowResults()
    {
        Debug.Log("SHOW RESULTS");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // знаходимо переможця по часу
        PlayerRace winner = finishedPlayers[0];

        foreach (var p in finishedPlayers)
            if (p.finishTime < winner.finishTime)
                winner = p;

        if (players.Count > 0 && player1Text != null)
        {
            PlayerRace p1 = players[0];
            player1Text.text = p1.playerName +  (p1 == winner ? " WIN" : " LOSE");
        }

        if (players.Count > 1 && player2Text != null)
        {
            PlayerRace p2 = players[1];
            player2Text.text = p2.playerName +  (p2 == winner ? " WIN" : " LOSE");
        }

        Time.timeScale = 0.01f; // майже стоп, але кнопки працюють

    }
}
