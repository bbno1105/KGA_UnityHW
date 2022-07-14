using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerInfo : MonoBehaviour
{
    public bool IsOn;

    public int score { get; set; }
    public int bestScore { get; set; }

    public TextMeshProUGUI txtBestScore;
    public TextMeshProUGUI txtScore;
}
