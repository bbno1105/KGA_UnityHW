using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool _isGameOver;

    public TimerInfo timerInfo;
    public GameObject gameOverUI;

    void Update()
    {
        if(_isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void End()
    {
        timerInfo.IsOn = false;

        // 데이터 저장
        int saveBestScore = PlayerPrefs.GetInt("BestScore", 0);
        int Score = Mathf.Max(saveBestScore,timerInfo.score);
        timerInfo.bestScore = Score;
        PlayerPrefs.SetInt("BestScore", Score);

        // GameOverUI에다가 갱신
        gameOverUI.SetActive(true);

        // _isOver = true;
        _isGameOver = true;
    }
}
