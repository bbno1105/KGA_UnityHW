using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public bool Up { get; private set; }
    public bool Down { get; private set; } 
    public bool Left { get; private set; } 
    public bool Right { get; private set; }

    GameObject _playerChar;
    PlayerHealth _health;

    void Start()
    {
        _health = GetComponent<PlayerHealth>();
    }

    public void InputMoveKey()
    {
        playerInfo.inputKey = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerInfo.isMove = playerInfo.inputKey.magnitude != 0;
    }
}
