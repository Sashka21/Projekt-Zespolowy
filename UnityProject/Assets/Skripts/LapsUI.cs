using UnityEngine;
using TMPro;

public class LapsUI : MonoBehaviour
{
    public TMP_Text lapsText;   // текст между стрелками

    public int minLaps = 1;
    public int maxLaps = 10;

    private int currentLaps = 3;

    void Start()
    {
        // если игрок уже выбирал круги раньше
        if (GameData.laps > 0)
            currentLaps = GameData.laps;

        UpdateText();
    }

    // кнопка LEFT
    public void Left()
    {
        currentLaps--;

        if (currentLaps < minLaps)
            currentLaps = minLaps;

        UpdateText();
    }

    // кнопка RIGHT
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
