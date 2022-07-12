using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerInfo playerInfo;

    GameObject _playerChar;
    GameObject _camera;
    Animator _animator;

    void Start()
    {
        _playerChar = this.transform.GetChild(0).gameObject;
        _camera = this.transform.GetChild(1).gameObject;
        _animator = _playerChar.GetComponent<Animator>();
    }

    void Update()
    {
        if (playerInfo.isDie) return;
        Move();
    }

    void Move()
    {
        if (playerInfo.isMove)
        {
            _animator.SetBool("isMove", true);

            Vector3 lookForward = new Vector3(_camera.transform.forward.x, 0f, _camera.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(_camera.transform.right.x, 0f, _camera.transform.right.z).normalized;

            Vector3 moveDir = lookForward * playerInfo.inputKey.y + lookRight * playerInfo.inputKey.x;

            _playerChar.transform.forward = moveDir;
            this.transform.position += moveDir * Time.deltaTime * playerInfo.moveSpeed;
        }
        else
        {
            _animator.SetBool("isMove", false);
        }
    }

}