using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameManager gameManager;

    public void Die()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        playerInfo.isDie = true;
        gameManager.isGameOver = true;
    }

    public void Respawn()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        playerInfo.isDie = false;
        gameManager.isGameOver = false;
        gameManager.score = 0;
    }
}
