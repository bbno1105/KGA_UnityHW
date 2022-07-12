using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public float score = 0;
    float _bestScore = 0;

    [Header("ÅØ½ºÆ®")]
    public Text txtBestScore;
    public Text txtScore;

    void Update()
    {
        if (isGameOver) return;

        Score();
        RefreshUI();
    }

    void Score()
    {
        score += Time.deltaTime;
        if (score >= _bestScore)
        {
            _bestScore = score;
        }
    }

    void RefreshUI()
    {
        txtScore.text = (int)(score / 60) + " : " + (int)(score % 60);
        txtBestScore.text = "Best Time : " + (int)(_bestScore / 60) + " : " + (int)(_bestScore % 60);
    }
}
