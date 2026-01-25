using UnityEngine;
using TMPro;

public class LapsSelector : MonoBehaviour
{
    public TMP_Text lapsText;

    public int minLaps = 1;
    public int maxLaps = 10;

    private int currentLaps = 3;

    void Start()
    {
        if (GameData.laps > 0)
            currentLaps = GameData.laps;

        UpdateText();
    }

    public void Left()
    {
        currentLaps--;
        if (currentLaps < minLaps)
            currentLaps = minLaps;

        UpdateText();
    }

    public void Right()
    {
        currentLaps++;
        if (currentLaps > maxLaps)
            currentLaps = maxLaps;

        UpdateText();
    }

    void UpdateText()
    {
        lapsText.text = currentLaps.ToString();
        GameData.laps = currentLaps;
    }
}
