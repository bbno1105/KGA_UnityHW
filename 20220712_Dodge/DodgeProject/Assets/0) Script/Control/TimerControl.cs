using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public TimerInfo timerInfo;

    float textTime = 1;

    void Start()
    {
        timerInfo.IsOn = true;
        timerInfo.bestScore = PlayerPrefs.GetInt("BestScore");
    }

    void Update()
    {
        if (timerInfo.IsOn)
        {
            textTime += Time.deltaTime;
            if (textTime > 1)
            {
                textTime = 0;
                Score();
            }
        }
        RefreshUI();
    }

    void Score()
    {
        timerInfo.score += 1;
    }

    void RefreshUI()
    {
        timerInfo.txtScore.text = (int)(timerInfo.score / 60) + " : " + (int)(timerInfo.score % 60);
        timerInfo.txtBestScore.text = $"Best Time : {(int)(timerInfo.bestScore / 60)} : {(int)(timerInfo.bestScore % 60)}";
    }
}
