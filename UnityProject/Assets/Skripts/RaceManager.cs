using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaceManager : MonoBehaviour
{
    private List<PlayerRace> finishOrder = new List<PlayerRace>();

    public void PlayerFinished(PlayerRace player)
    {
        if (finishOrder.Contains(player)) return;

        finishOrder.Add(player);
        int position = finishOrder.Count;
        Debug.Log($"{player.playerName} finished at place {position}! time={player.finishTime:F2}s");

        // Optional: do more — stop player's movement, show UI, check if all finished, etc.
    }

    // helper: count checkpoints in scene (optional)
    public int CountCheckpointsInScene()
    {
        var cps = FindObjectsOfType<Checkpoint>();
        return cps.Length;
    }
}