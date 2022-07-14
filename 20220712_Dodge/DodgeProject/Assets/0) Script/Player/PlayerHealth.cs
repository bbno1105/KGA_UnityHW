using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameManager gameManager;

    public GameObject playerChar;

    public void Die()
    {
        // playerChar.SetActive(false);
        // playerInfo.isDie = true;
        // gameManager.End();
    }

    public void Respawn()
    {
        playerChar.SetActive(true);
        playerInfo.isDie = false;
    }
}
