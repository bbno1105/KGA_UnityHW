using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public PlayerHealth playerHelth;
    public PlayerMove playerMove;
    public PlayerInput playerInput;

    void Update()
    {
        if (!playerInfo.isDie)
        {
            playerInput.InputMoveKey();
            playerMove.Move();
            playerMove.Attack();
        }
    }
}
