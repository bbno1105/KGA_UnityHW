using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI bestTimeUI;
    public TimerInfo timerInfo;

    public void UpdateBestTime()
    {
        if (timerInfo.score >= timerInfo.bestScore)
        {
            timerInfo.bestScore = (int)timerInfo.score;
        }
    }
}
